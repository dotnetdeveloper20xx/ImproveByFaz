using ImproveByFaz.Domain.Enums;

namespace ImproveByFaz.Application.DTOs
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<string> Choices { get; set; } = new();
        public AnswerChoice CorrectAnswer { get; set; }
        public string Explanation { get; set; } = string.Empty;
    }
}
