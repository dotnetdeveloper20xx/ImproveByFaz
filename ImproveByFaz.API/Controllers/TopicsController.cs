using ImproveByFaz.Application.Features.Topics.GetTopicsWithMisconceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Caching.Memory;


namespace ImproveByFaz.API.Controllers
{
    [Route("api/topics")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly IMemoryCache _cache;
        public TopicsController(IMediator mediator          
            /*,IMemoryCache cache*/)
        {
            _mediator = mediator;
            //_cache = cache;
        }

        /// <summary>
        /// Retrieves topics where the student has misconceptions.
        /// </summary>
        [HttpGet("{studentId}")]
        //[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)] // Cache Response for 60 Seconds

        public async Task<IActionResult> GetTopicsWithMisconceptions(int studentId)
        {
            //var cacheKey = "topicsList";
            //if (!_cache.TryGetValue(cacheKey, out List<Application.DTOs.TopicDto> result))
            //{
            //    List<Application.DTOs.TopicDto> result = await _mediator.Send(new GetTopicsWithMisconceptionsQuery(studentId));
            //    _cache.Set(cacheKey, result, TimeSpan.FromSeconds(60)); // Store in Cache
            //}

            List<Application.DTOs.TopicDto> result = await _mediator.Send(new GetTopicsWithMisconceptionsQuery(studentId));
            return Ok(result);
        }
    }
}
