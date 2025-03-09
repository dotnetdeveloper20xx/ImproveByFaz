using MediatR;
using ImproveByFaz.Domain.Interfaces;
using ImproveByFaz.Domain.Events;

namespace ImproveByFaz.Application.Features.Questions.SubmitAnswer
{
    public class SubmitAnswerHandler : IRequestHandler<SubmitAnswerCommand, SubmitAnswerResponse>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IStudentRepository _studentRepository;

        public SubmitAnswerHandler(IQuestionRepository questionRepository, IStudentRepository studentRepository)
        {
            _questionRepository = questionRepository;
            _studentRepository = studentRepository;
        }

        public async Task<SubmitAnswerResponse> Handle(SubmitAnswerCommand request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetMisconceptionQuestionsAsync(request.StudentId, request.QuestionId);
            var question = questions.FirstOrDefault(q => q.Id == request.QuestionId);
            if (question == null) return new SubmitAnswerResponse(false, "Invalid Question");

            bool isCorrect = question.CorrectAnswer.ToString() == request.SelectedAnswer;

            if (isCorrect)
            {
                await _studentRepository.MarkMisconceptionAsCorrectedAsync(request.StudentId, request.QuestionId);
            }

            return new SubmitAnswerResponse(isCorrect, isCorrect ? "Correct! Well done!" : "Incorrect. Try again!");
        }
    }
}
