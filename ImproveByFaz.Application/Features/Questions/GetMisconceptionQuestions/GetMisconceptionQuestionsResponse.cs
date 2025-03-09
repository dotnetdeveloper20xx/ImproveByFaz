using ImproveByFaz.Application.DTOs;

namespace ImproveByFaz.Application.Features.Questions.GetMisconceptionQuestions
{
    public record GetMisconceptionQuestionsResponse(List<QuestionDto> Questions);
}
