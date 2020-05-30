using Microsoft.AspNetCore.Mvc;
using Template.Application.TodoItems.Commands.CreateTodoItem;

namespace WebUI.Components.TodoItems
{
    public class CreateTodoItemViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int listId)
        {
            var command = new CreateTodoItemCommand() { ListId = listId };
            return View(command);
        }
    }
}
