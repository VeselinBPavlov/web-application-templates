using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Template.WebUI.Shared.Common.Interfaces;
using Template.WebUI.Shared.Common.Models;
using Template.WebUI.Shared.TodoItems.Commands.CreateTodoItem;
using Template.WebUI.Shared.TodoItems.Commands.UpdateTodoItem;
using Template.WebUI.Shared.TodoItems.Commands.UpdateTodoItemDetail;
using Template.WebUI.Shared.TodoLists.Commands.CreateTodoList;
using Template.WebUI.Shared.TodoLists.Commands.UpdateTodoList;
using Template.WebUI.Shared.TodoLists.Queries.GetTodos;

namespace Template.WebUI.Client.Infrastructure
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient httpClient;

        public ApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private async Task<ApiResponse<T>> GetJson<T>(string url)
        {
            try
            {
                return await this.httpClient.GetFromJsonAsync<ApiResponse<T>>(url);
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>(new ApiError("HTTP Client", ex.Message));
            }
        }

        private async Task<ApiResponse<TResponse>> PostJson<TRequest, TResponse>(string url, TRequest request)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync(url, request);
                var responseObject = await response.Content.ReadFromJsonAsync<ApiResponse<TResponse>>();
                return responseObject;
            }
            catch (Exception ex)
            {
                return new ApiResponse<TResponse>(new ApiError("HTTP Client", ex.Message));
            }
        }

        private async Task PutJson<T>(string url, T request)
        {
            try
            {
                await this.httpClient.PutAsJsonAsync(url, request);
            }
            catch (Exception ex)
            {
                new ApiResponse<T>(new ApiError("HTTP Client", ex.Message));
            }
        }

        private async Task Delete(string url)
        {
            try
            {
                await this.httpClient.DeleteAsync(url);
            }
            catch (Exception ex)
            {
                new ApiError("HTTP Client", ex.Message);
            }
        }

        public Task<ApiResponse<TodosVm>> GetTodoLists() =>
            this.GetJson<TodosVm>("api/TodoLists");

        public Task<ApiResponse<int>> CreateTodoList(CreateTodoListCommand command) =>
            this.PostJson<CreateTodoListCommand, int>("api/TodoLists", command);

        public Task UpdateTodoList(UpdateTodoListCommand command) =>
            this.PutJson("api/TodoLists", command);

        public Task DeleteTodoList(int id) =>
            this.Delete($"api/TodoLists/{id}");

        public Task<ApiResponse<int>> CreateTodoItem(CreateTodoItemCommand command) =>
            this.PostJson<CreateTodoItemCommand, int>("api/TodoItems", command);

        public Task UpdateTodoItem(UpdateTodoItemCommand command) =>
            this.PutJson("api/TodoItems", command);

        public Task UpdateTodoItemDetails(UpdateTodoItemDetailCommand command) =>
          this.PutJson("api/TodoItems/UpdateItemDetails", command);

        public Task DeleteTodoItem(int id) =>
            this.Delete($"api/TodoItems/{id}");
    }
}
