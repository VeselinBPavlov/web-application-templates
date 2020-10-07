using System.Collections.Generic;
using Template.WebUI.Shared.TodoLists.Queries.ExportTodos;

namespace Template.WebUI.Shared.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
