namespace ImproveByFaz.Domain.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<SubTopic> SubTopics { get; set; } = new();
    }
}
