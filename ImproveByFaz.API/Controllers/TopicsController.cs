using ImproveByFaz.Application.Features.Topics.GetTopicsWithMisconceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ImproveByFaz.API.Controllers
{
    [Route("api/topics")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TopicsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves topics where the student has misconceptions.
        /// </summary>
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetTopicsWithMisconceptions(int studentId)
        {
            var result = await _mediator.Send(new GetTopicsWithMisconceptionsQuery(studentId));
            return Ok(result);
        }
    }
}
