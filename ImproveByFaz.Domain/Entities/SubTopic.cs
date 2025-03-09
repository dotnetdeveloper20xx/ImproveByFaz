namespace ImproveByFaz.Domain.Entities
{
    public class SubTopic
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public List<Question> Questions { get; set; } = new();
    }
}
