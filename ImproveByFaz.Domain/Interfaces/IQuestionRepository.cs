using ImproveByFaz.Domain.Entities;

namespace ImproveByFaz.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetMisconceptionQuestionsAsync(int studentId, int subTopicId);
    }
}
