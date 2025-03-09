using MediatR;
using ImproveByFaz.Application.Features.Questions.SubmitAnswer;

namespace ImproveByFaz.Application.Features.Questions.SubmitAnswer
{
    public record SubmitAnswerCommand(int StudentId, int QuestionId, string SelectedAnswer) : IRequest<SubmitAnswerResponse>;
}
