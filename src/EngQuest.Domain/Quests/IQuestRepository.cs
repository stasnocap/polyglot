namespace EngQuest.Domain.Quests;

public interface IQuestRepository
{
    Task<bool> ExistsAsync(int questId, CancellationToken cancellationToken);
    Task<Quest?> GetByIdAsync(int questId, CancellationToken cancellationToken);
    Task<List<Quest>> GetRangeAsync(int? userId, string? searchTerm, CancellationToken cancellationToken);
}
