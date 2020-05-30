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
            var result = await Mediator.Send(new GetTodosQuery());
            return View(result);
        }
    }
}
