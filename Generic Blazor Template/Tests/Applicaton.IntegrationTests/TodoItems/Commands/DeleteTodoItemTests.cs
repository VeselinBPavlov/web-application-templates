using Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using WebUI.Shared.TodoItems.Commands.CreateTodoItem;
using WebUI.Shared.TodoItems.Commands.DeleteTodoItem;
using WebUI.Shared.TodoLists.Commands.CreateTodoList;
using WebUI.Shared.Common.Exceptions;

namespace Template.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class DeleteTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new DeleteTodoItemCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoItem()
        {
            var response = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var listId = response.Data;

            response = await SendAsync(new CreateTodoItemCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            var itemId = response.Data;

            await SendAsync(new DeleteTodoItemCommand
            {
                Id = itemId
            });

            var list = await FindAsync<TodoItem>(listId);

            list.Should().BeNull();
        }
    }
}
