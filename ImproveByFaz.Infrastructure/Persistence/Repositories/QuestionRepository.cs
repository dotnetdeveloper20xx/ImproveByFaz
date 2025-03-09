using ImproveByFaz.Domain.Entities;
using ImproveByFaz.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImproveByFaz.Infrastructure.Persistence.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ImproveDbContext _context;

        public QuestionRepository(ImproveDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetMisconceptionQuestionsAsync(int studentId, int subTopicId)
        {
            return await _context.StudentMisconceptions
                .Where(m => m.StudentId == studentId && !m.IsCorrected)
                .Select(m => m.Question)
                .Where(q => q.SubTopicId == subTopicId)
                .ToListAsync();
        }
    }
}
