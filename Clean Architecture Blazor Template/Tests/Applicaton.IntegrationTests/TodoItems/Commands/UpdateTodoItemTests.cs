﻿using Template.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;
using Template.WebUI.Shared.TodoItems.Commands.CreateTodoItem;
using Template.WebUI.Shared.TodoItems.Commands.UpdateTodoItem;
using Template.WebUI.Shared.TodoLists.Commands.CreateTodoList;
using Template.WebUI.Shared.Common.Exceptions;

namespace Template.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class UpdateTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new UpdateTodoItemCommand
            {
                Id = 99,
                Title = "New Title"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();

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

            var command = new UpdateTodoItemCommand
            {
                Id = itemId,
                Title = "Updated Item Title"
            };

            await SendAsync(command);

            var item = await FindAsync<TodoItem>(itemId);

            item.Title.Should().Be(command.Title);
            item.LastModifiedBy.Should().NotBeNull();
            item.LastModifiedBy.Should().Be(userId);
            item.LastModified.Should().NotBeNull();
            item.LastModified.Should().BeCloseTo(DateTime.Now, 1000);
        }
    }
}
