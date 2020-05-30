using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Template.Application.TodoLists.Queries.GetTodos;

namespace WebUI.Components.TodoLists
{
    public class TodoListsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IList<TodoListDto> list)
        {
            return View(list);
        }
    }
}
