namespace ImproveByFaz.Application.DTOs
{
    public class StudentProgressDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TotalMisconceptions { get; set; }
        public int CorrectedMisconceptions { get; set; }
    }
}
