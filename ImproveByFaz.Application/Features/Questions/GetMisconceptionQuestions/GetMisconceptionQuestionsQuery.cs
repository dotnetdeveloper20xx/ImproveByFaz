using MediatR;
using ImproveByFaz.Application.DTOs;

namespace ImproveByFaz.Application.Features.Questions.GetMisconceptionQuestions
{
    public record GetMisconceptionQuestionsQuery(int StudentId, int SubTopicId) : IRequest<List<QuestionDto>>;
}
