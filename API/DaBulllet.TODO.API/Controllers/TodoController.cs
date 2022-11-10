using Application.TodoItems.Commands.CreateTodoItem;
using Application.TodoItems.Commands.DeleteTodoItem;
using Application.TodoItems.Queries.GetTodoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaBulllet.TODO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get the todoitems
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<GetTodoItemsQueryResponse>> GetTodoItems() => await _mediator.Send(new GetTodoItemsQuery());

        /// <summary>
        /// Create a new TodoItem
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTodoItem([FromBody] CreateTodoItemCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// Delete a TodoItem
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            await _mediator.Send(new DeleteTodoItemCommand { Id = id });

            return Ok();
        }
    }
}
