namespace ImproveByFaz.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<StudentMisconception> Misconceptions { get; set; } = new();
    }
}
