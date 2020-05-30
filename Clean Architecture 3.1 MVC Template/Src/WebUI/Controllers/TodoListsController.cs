using Template.Application.TodoLists.Commands.CreateTodoList;
using Template.Application.TodoLists.Commands.DeleteTodoList;
using Template.Application.TodoLists.Commands.UpdateTodoList;
using Template.Application.TodoLists.Queries.ExportTodos;
using Template.Application.TodoLists.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Template.WebUI.Controllers
{
    [Authorize]
    public class TodoListsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<TodosVm>> Get()
        {
            return await Mediator.Send(new GetTodosQuery());
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportTodosQuery { ListId = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoListCommand command)
        {
            await Mediator.Send(command);

            return this.Redirect("/Todo");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTodoListCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Delete([FromForm]int id)
        {
            await Mediator.Send(new DeleteTodoListCommand { Id = id });

            return this.Redirect("/Todo");
        }
    }
}
