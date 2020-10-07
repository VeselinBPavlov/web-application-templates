using Template.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using Template.WebUI.Shared.TodoLists.Commands.CreateTodoList;
using Template.WebUI.Shared.TodoLists.Commands.DeleteTodoList;
using Template.WebUI.Shared.Common.Exceptions;

namespace Template.Application.IntegrationTests.TodoLists.Commands
{
    using static Testing;

    public class DeleteTodoListTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new DeleteTodoListCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoList()
        {
            var response = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var listId = response.Data;

            await SendAsync(new DeleteTodoListCommand 
            { 
                Id = listId 
            });

            var list = await FindAsync<TodoList>(listId);

            list.Should().BeNull();
        }
    }
}
