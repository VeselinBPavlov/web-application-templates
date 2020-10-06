using System.Threading.Tasks;
using Template.WebUI.Shared.Common.Models;
using Template.WebUI.Shared.TodoItems.Commands.CreateTodoItem;
using Template.WebUI.Shared.TodoItems.Commands.UpdateTodoItem;
using Template.WebUI.Shared.TodoItems.Commands.UpdateTodoItemDetail;
using Template.WebUI.Shared.TodoLists.Commands.CreateTodoList;
using Template.WebUI.Shared.TodoLists.Commands.UpdateTodoList;
using Template.WebUI.Shared.TodoLists.Queries.GetTodos;

namespace Template.WebUI.Shared.Common.Interfaces
{
    public interface IApiClient
    {
        Task<ApiResponse<TodosVm>> GetTodoLists();
        Task<ApiResponse<int>> CreateTodoList(CreateTodoListCommand command);
        Task UpdateTodoList(UpdateTodoListCommand command);
        Task DeleteTodoList(int id);

        Task<ApiResponse<int>> CreateTodoItem(CreateTodoItemCommand command);
        Task UpdateTodoItem(UpdateTodoItemCommand command);
        Task UpdateTodoItemDetails(UpdateTodoItemDetailCommand command);
        Task DeleteTodoItem(int id);
    }
}
