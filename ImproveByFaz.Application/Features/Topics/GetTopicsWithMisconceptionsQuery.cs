using MediatR;
using ImproveByFaz.Application.DTOs;

namespace ImproveByFaz.Application.Features.Topics.GetTopicsWithMisconceptions
{
    public record GetTopicsWithMisconceptionsQuery(int StudentId) : IRequest<List<TopicDto>>;
}
