using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Template.Application.TodoLists.Queries.GetTodos;

namespace WebUI.Components.TodoLists
{
    public class TodoListsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(TodosVm model)
        {
            return View(model);
        }
    }
}
