namespace ImproveByFaz.Domain.ValueObjects
{
    public class AnswerOption
    {
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public AnswerOption() { }

        public AnswerOption(string label, string description)
        {
            Label = label;
            Description = description;
        }
    }
}
