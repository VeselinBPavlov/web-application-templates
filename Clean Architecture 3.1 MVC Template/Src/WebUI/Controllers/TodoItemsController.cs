using Template.Application.TodoItems.Commands.CreateTodoItem;
using Template.Application.TodoItems.Commands.DeleteTodoItem;
using Template.Application.TodoItems.Commands.UpdateTodoItem;
using Template.Application.TodoItems.Commands.UpdateTodoItemDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Application.TodoItems.Queries.GetSelectedListItems;

namespace Template.WebUI.Controllers
{
    [Authorize]
    public class TodoItemsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
        {
            await Mediator.Send(command);

            return this.Redirect("/Todo");
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


        public async Task<ActionResult> Get(int id)
        {
            await Mediator.Send(new GetSelectedListItemsQuery() { Id = id });

            return this.Redirect("/Todo");
        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromForm]int id)
        {
            await Mediator.Send(new DeleteTodoItemCommand { Id = id });

            return this.Redirect("/Todo");
        }
    }
}
