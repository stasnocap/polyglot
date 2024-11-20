namespace EngQuest.Domain.Levels;

public interface ILevelRepository
{
    Task<Level?> GetByUserIdAsync(int userId, CancellationToken cancellationToken);
    void Add(Level level);
}
