using Application.TodoItems.Commands.DeleteTodoItem;
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
    public class DeleteTodoItemCommandTest : TestBase
    {
        [Test]
        public async Task TodoItem_IsDeleted_WhenValidIdIsProvided()
        {
            var httpClient = CreateTestClient();

            var result = await httpClient.DeleteAsync($"api/todo/{Guid.Parse("4cb3368c-2933-4b79-9b74-a959a5a4fdac")}");

            result.Should().HaveStatusCode(HttpStatusCode.OK);
        }

        [Test]
        public async Task TodoItem_IsNotDeleted_WhenInvalidIdIsProvided()
        {
            var httpClient = CreateTestClient();

            var command = new DeleteTodoItemCommand
            {
                Id = Guid.NewGuid()
            };

            var result = await httpClient.DeleteAsync($"api/todo/{command.Id}");

            result.Should().HaveStatusCode(HttpStatusCode.NotFound);
        }
    }
}
