using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DaBulllet.TODO.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {

        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("OK");
        }
    }
}
