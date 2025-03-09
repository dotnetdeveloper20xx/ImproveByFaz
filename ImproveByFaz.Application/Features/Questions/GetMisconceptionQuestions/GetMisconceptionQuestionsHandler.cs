using MediatR;
using ImproveByFaz.Application.DTOs;
using ImproveByFaz.Domain.Interfaces;

namespace ImproveByFaz.Application.Features.Questions.GetMisconceptionQuestions
{
    public class GetMisconceptionQuestionsHandler : IRequestHandler<GetMisconceptionQuestionsQuery, List<QuestionDto>>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetMisconceptionQuestionsHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<List<QuestionDto>> Handle(GetMisconceptionQuestionsQuery request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetMisconceptionQuestionsAsync(request.StudentId, request.SubTopicId);

            return questions.Select(q => new QuestionDto
            {
                QuestionId = q.Id,
                ImageUrl = q.ImageUrl,
                Choices = q.Options.Select(o => o.Label).ToList(),
                CorrectAnswer = q.CorrectAnswer,
                Explanation = q.Explanation
            }).ToList();
        }
    }
}
