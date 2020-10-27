using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Shared.Common.Models;
using WebUI.Shared.TodoItems.Commands.CreateTodoItem;
using WebUI.Shared.TodoItems.Commands.DeleteTodoItem;
using WebUI.Shared.TodoItems.Commands.UpdateTodoItem;
using WebUI.Shared.TodoItems.Commands.UpdateTodoItemDetail;
using WebUI.Shared.TodoItems.Queries.GetTodoItemsWithPagination;
using WebUI.Shared.TodoLists.Queries.GetTodos;

namespace WebUI.Server.Controllers
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
        public async Task<ApiResponse<int>> Create(CreateTodoItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateTodoItemCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(UpdateTodoItemDetailCommand command)
        {
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
