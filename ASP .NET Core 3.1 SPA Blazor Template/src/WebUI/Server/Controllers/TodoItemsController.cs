using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.WebUI.Shared.Common.Models;
using Template.WebUI.Shared.TodoItems.Commands.CreateTodoItem;
using Template.WebUI.Shared.TodoItems.Commands.DeleteTodoItem;
using Template.WebUI.Shared.TodoItems.Commands.UpdateTodoItem;
using Template.WebUI.Shared.TodoItems.Commands.UpdateTodoItemDetail;
using Template.WebUI.Shared.TodoItems.Queries.GetTodoItemsWithPagination;
using Template.WebUI.Shared.TodoLists.Queries.GetTodos;

namespace Template.WebUI.Server.Controllers
{
    [Authorize]
    public class TodoItemsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<TodoItemDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTodoItemCommand { Id = id });

            return NoContent();
        }
    }
}
