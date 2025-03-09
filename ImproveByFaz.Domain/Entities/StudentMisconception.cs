namespace ImproveByFaz.Domain.Entities
{
    public class StudentMisconception
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public bool IsCorrected { get; set; } = false;
    }
}
