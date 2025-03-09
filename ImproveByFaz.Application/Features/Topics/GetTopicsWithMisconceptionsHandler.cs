using MediatR;
using ImproveByFaz.Application.DTOs;
using ImproveByFaz.Domain.Interfaces;

namespace ImproveByFaz.Application.Features.Topics.GetTopicsWithMisconceptions
{
    public class GetTopicsWithMisconceptionsHandler : IRequestHandler<GetTopicsWithMisconceptionsQuery, List<TopicDto>>
    {
        private readonly ITopicRepository _topicRepository;

        public GetTopicsWithMisconceptionsHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<List<TopicDto>> Handle(GetTopicsWithMisconceptionsQuery request, CancellationToken cancellationToken)
        {
            var topics = await _topicRepository.GetTopicsWithMisconceptionsAsync(request.StudentId);
            return topics.Select(t => new TopicDto
            {
                TopicId = t.Id,
                Name = t.Name,
                SubTopics = t.SubTopics.Select(st => new SubTopicDto
                {
                    SubTopicId = st.Id,
                    Name = st.Name,
                    Misconceptions = st.Questions.Count
                }).ToList()
            }).ToList();
        }
    }
}
