using ImproveByFaz.Domain.Entities;

namespace ImproveByFaz.Domain.Interfaces
{
    public interface ITopicRepository
    {
        Task<List<Topic>> GetTopicsWithMisconceptionsAsync(int studentId);
    }
}
