using ImproveByFaz.Domain.Entities;

namespace ImproveByFaz.Domain.Specifications
{
    public class MisconceptionsByStudentSpecification
    {
        public static Func<StudentMisconception, bool> GetMisconceptions(int studentId) =>
            misconception => misconception.StudentId == studentId && !misconception.IsCorrected;
    }
}
