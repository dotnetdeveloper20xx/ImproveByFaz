using ImproveByFaz.Application.Features.Students.GetStudentProgress;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ImproveByFaz.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
     

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
           
        }

        /// <summary>
        /// Retrieves progress for a specific student.
        /// </summary>
        [HttpGet("{studentId}/progress")]
        public async Task<IActionResult> GetStudentProgress(int studentId)
        {          
            var result = await _mediator.Send(new GetStudentProgressQuery(studentId));
            return Ok(result);
        }
    }
}
