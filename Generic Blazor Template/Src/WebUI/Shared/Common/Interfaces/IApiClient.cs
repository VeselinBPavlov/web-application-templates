using System.Threading.Tasks;
using WebUI.Shared.Common.Models;
using WebUI.Shared.TodoItems.Commands.CreateTodoItem;
using WebUI.Shared.TodoItems.Commands.UpdateTodoItem;
using WebUI.Shared.TodoItems.Commands.UpdateTodoItemDetail;
using WebUI.Shared.TodoLists.Commands.CreateTodoList;
using WebUI.Shared.TodoLists.Commands.UpdateTodoList;
using WebUI.Shared.TodoLists.Queries.GetTodos;

namespace WebUI.Shared.Common.Interfaces
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
