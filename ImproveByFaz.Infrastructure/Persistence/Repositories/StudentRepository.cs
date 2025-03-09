using ImproveByFaz.Domain.Entities;
using ImproveByFaz.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImproveByFaz.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ImproveDbContext _context;

        public StudentRepository(ImproveDbContext context)
        {
            _context = context;
        }

        public async Task<Student?> GetStudentByIdAsync(int studentId)
        {
            return await _context.Students.Include(s => s.Misconceptions).FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task<List<StudentMisconception>> GetStudentMisconceptionsAsync(int studentId)
        {
            return await _context.StudentMisconceptions
                .Include(m => m.Question)
                .Where(m => m.StudentId == studentId && !m.IsCorrected)
                .ToListAsync();
        }

        public async Task MarkMisconceptionAsCorrectedAsync(int studentId, int questionId)
        {
            var misconception = await _context.StudentMisconceptions
                .FirstOrDefaultAsync(m => m.StudentId == studentId && m.QuestionId == questionId);

            if (misconception != null)
            {
                misconception.IsCorrected = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
