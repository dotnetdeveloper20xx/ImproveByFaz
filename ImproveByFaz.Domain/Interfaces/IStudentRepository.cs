using ImproveByFaz.Domain.Entities;

namespace ImproveByFaz.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student?> GetStudentByIdAsync(int studentId);
        Task<List<StudentMisconception>> GetStudentMisconceptionsAsync(int studentId);
        Task MarkMisconceptionAsCorrectedAsync(int studentId, int questionId);
    }
}
