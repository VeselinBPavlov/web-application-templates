﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.WebUI.Server.Controllers;
using Template.WebUI.Shared.Common.Models;
using Template.WebUI.Shared.TodoLists.Commands.CreateTodoList;
using Template.WebUI.Shared.TodoLists.Commands.DeleteTodoList;
using Template.WebUI.Shared.TodoLists.Commands.UpdateTodoList;
using Template.WebUI.Shared.TodoLists.Queries.ExportTodos;
using Template.WebUI.Shared.TodoLists.Queries.GetTodos;

namespace CleanArchitecture.WebUI.Controllers
{
    [Authorize]
    public class TodoListsController : ApiController
    {
        [HttpGet]
        public async Task<ApiResponse<TodosVm>> Get()
        {
            return await Mediator.Send(new GetTodosQuery());        
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportTodosQuery { ListId = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ApiResponse<int>> Create(CreateTodoListCommand command)
        {
            return await Mediator.Send(command);       
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateTodoListCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTodoListCommand { Id = id });

            return NoContent();
        }
    }
}
