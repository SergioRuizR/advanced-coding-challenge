using Application.TodoItems.Queries.GetTodoItems;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Da.Bullet.TODO.API.IntegrationTests.TodoItems
{
    public class GetTodoItemsQueryTests : TestBase
    {
        [Test]
        public async Task TodoItems_Obtained()
        {
            var httpClient = CreateTestClient();

            List<GetTodoItemsQueryResponse> items = await httpClient.GetFromJsonAsync<List<GetTodoItemsQueryResponse>>("/api/todo");

            items.Should().NotBeNullOrEmpty();
            items?.Count.Should().Be(3);
        }
    }
}
