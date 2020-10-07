using Template.Domain.Entities;
using Template.WebUI.Shared.Common.Mappings;

namespace Template.WebUI.Shared.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
