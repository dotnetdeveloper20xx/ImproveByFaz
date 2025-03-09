using ImproveByFaz.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ImproveByFaz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Throws a general unhandled exception.
        /// </summary>
        [HttpGet("test-exception")]
        public IActionResult TestException()
        {
            throw new Exception("This is a test unhandled exception!");
        }

        /// <summary>
        /// Throws a controlled custom exception.
        /// </summary>
        [HttpGet("test-custom-exception")]
        public IActionResult TestCustomException()
        {
            throw new CustomException("This is a controlled bad request!", 400);
        }
    }
}
