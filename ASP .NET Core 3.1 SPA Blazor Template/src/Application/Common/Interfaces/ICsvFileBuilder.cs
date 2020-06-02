using Template.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Template.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
