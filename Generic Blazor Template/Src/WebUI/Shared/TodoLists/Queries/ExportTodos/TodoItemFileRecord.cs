using Domain.Entities;
using WebUI.Shared.Common.Mappings;

namespace WebUI.Shared.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
