﻿using WebUI.Shared.Common.Exceptions;
using Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WebUI.Shared.TodoLists.Commands.CreateTodoList;

namespace Template.Application.IntegrationTests.TodoLists.Commands
{
    using static Testing;

    public class CreateTodoListTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateTodoListCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldRequireUniqueTitle()
        {
            await SendAsync(new CreateTodoListCommand
            {
                Title = "Shopping"
            });

            var command = new CreateTodoListCommand
            {
                Title = "Shopping"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateTodoList()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreateTodoListCommand
            {
                Title = "Tasks"
            };

            var response = await SendAsync(command);

            var id = response.Data;

            var list = await FindAsync<TodoList>(id);

            list.Should().NotBeNull();
            list.Title.Should().Be(command.Title);
            list.CreatedBy.Should().Be(userId);
            list.Created.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
