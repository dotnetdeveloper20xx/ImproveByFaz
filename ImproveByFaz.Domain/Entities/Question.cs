using ImproveByFaz.Domain.Enums;
using ImproveByFaz.Domain.ValueObjects;

namespace ImproveByFaz.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public int SubTopicId { get; set; }
        public SubTopic SubTopic { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public AnswerChoice CorrectAnswer { get; set; }
        public string Explanation { get; set; } = string.Empty;
        public List<AnswerOption> Options { get; set; } = new();
    }
}
