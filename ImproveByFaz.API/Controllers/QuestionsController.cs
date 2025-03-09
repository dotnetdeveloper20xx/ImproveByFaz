using ImproveByFaz.Application.Features.Questions.GetMisconceptionQuestions;
using ImproveByFaz.Application.Features.Questions.SubmitAnswer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ImproveByFaz.API.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves questions that a student previously answered incorrectly.
        /// </summary>
        [HttpGet("{studentId}/{subTopicId}")]
        public async Task<IActionResult> GetMisconceptionQuestions(int studentId, int subTopicId)
        {
            var result = await _mediator.Send(new GetMisconceptionQuestionsQuery(studentId, subTopicId));
            return Ok(result);
        }

        /// <summary>
        /// Allows a student to re-answer a previously incorrect question.
        /// </summary>
        [HttpPost("submit-answer")]
        public async Task<IActionResult> SubmitAnswer([FromBody] SubmitAnswerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
