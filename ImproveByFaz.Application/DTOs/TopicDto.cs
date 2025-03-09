namespace ImproveByFaz.Application.DTOs
{
    public class TopicDto
    {
        public int TopicId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<SubTopicDto> SubTopics { get; set; } = new();
    }
}
