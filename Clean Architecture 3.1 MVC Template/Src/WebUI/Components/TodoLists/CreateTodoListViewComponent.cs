using Microsoft.AspNetCore.Mvc;
using Template.Application.TodoLists.Commands.CreateTodoList;

namespace WebUI.Components.TodoLists
{
    public class CreateTodoListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var command = new CreateTodoListCommand();
            return View(command);
        }
    }
}
