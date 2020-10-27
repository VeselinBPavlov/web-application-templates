using System.Collections.Generic;
using WebUI.Shared.TodoLists.Queries.ExportTodos;

namespace WebUI.Shared.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
