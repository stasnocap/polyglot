namespace EngQuest.Domain.Quests;

public interface IQuestRepository
{
    Task<List<Quest>> GetRangeAsync(int? userId, string? searchTerm, CancellationToken cancellationToken);
}
