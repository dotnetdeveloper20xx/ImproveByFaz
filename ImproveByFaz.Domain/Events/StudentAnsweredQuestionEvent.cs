using ImproveByFaz.Domain.Enums;

namespace ImproveByFaz.Domain.Events
{
    public class StudentAnsweredQuestionEvent
    {
        public int StudentId { get; }
        public int QuestionId { get; }
        public AnswerChoice SelectedAnswer { get; }
        public bool IsCorrect { get; }

        public StudentAnsweredQuestionEvent(int studentId, int questionId, AnswerChoice selectedAnswer, bool isCorrect)
        {
            StudentId = studentId;
            QuestionId = questionId;
            SelectedAnswer = selectedAnswer;
            IsCorrect = isCorrect;
        }
    }
}
