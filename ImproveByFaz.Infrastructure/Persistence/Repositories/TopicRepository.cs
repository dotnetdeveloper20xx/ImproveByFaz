using ImproveByFaz.Domain.Entities;
using ImproveByFaz.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImproveByFaz.Infrastructure.Persistence.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ImproveDbContext _context;

        public TopicRepository(ImproveDbContext context)
        {
            _context = context;
        }

        public async Task<List<Topic>> GetTopicsWithMisconceptionsAsync(int studentId)
        {
            return await _context.Topics
                .Include(t => t.SubTopics)
                .ThenInclude(st => st.Questions)
                .Where(t => t.SubTopics.Any(st => st.Questions.Any()))
                .ToListAsync();
        }
    }
}
