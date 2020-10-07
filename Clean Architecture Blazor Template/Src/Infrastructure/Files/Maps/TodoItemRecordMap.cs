using CsvHelper.Configuration;
using System.Globalization;
using Template.WebUI.Shared.TodoLists.Queries.ExportTodos;

namespace Template.Infrastructure.Files.Maps
{
    public class TodoItemRecordMap : ClassMap<TodoItemRecord>
    {
        public TodoItemRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
