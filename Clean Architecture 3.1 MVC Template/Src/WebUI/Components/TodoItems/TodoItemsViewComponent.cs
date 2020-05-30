using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Template.Application.TodoLists.Queries.GetTodos;

namespace WebUI.Components.TodoItems
{
    public class TodoItemsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IList<TodoItemDto> list)
        {
            return View(list);
        }
    }
}
