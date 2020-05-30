using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Application.TodoLists.Queries.GetTodos;
using Template.WebUI.Controllers;

namespace WebUI.Controllers
{
    public class TodoController : BaseController
    {
        public async Task<ActionResult<TodosVm>> Index()
        {
            return View(await Mediator.Send(new GetTodosQuery()));
        }
    }
}
