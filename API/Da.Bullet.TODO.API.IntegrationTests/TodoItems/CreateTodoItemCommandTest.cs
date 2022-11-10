using Application.TodoItems.Commands.CreateTodoItem;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Da.Bullet.TODO.API.IntegrationTests.TodoItems
{
    public class CreateTodoItemCommandTest : TestBase
    {
        [Test]
        public async Task TodoItem_IsCreated_WhenValidFieldsAreProvided()
        {
            var httpClient = CreateTestClient();

            var command = new CreateTodoItemCommand
            {
                Id = Guid.NewGuid(),
                Title = "Title test",
                Description = "Description test"
            };

            var result = await httpClient.PostAsJsonAsync("api/todo", command);

            FluentActions.Invoking(() => result.EnsureSuccessStatusCode())
                .Should().NotThrow();
        }

        [Test]
        public async Task TodoItem_IsNotCreated_WhenInvalidFieldsAreProvided()
        {
            var httpClient = CreateTestClient();

            var command = new CreateTodoItemCommand
            {
                Id = Guid.NewGuid(),
                Title = "",
                Description = "Description test"
            };

            var result = await httpClient.PostAsJsonAsync("api/todo", command);

            FluentActions.Invoking(() => result.EnsureSuccessStatusCode())
                .Should().Throw<HttpRequestException>();

            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
