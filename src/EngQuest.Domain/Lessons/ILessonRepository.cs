namespace EngQuest.Domain.Lessons;

public interface ILessonRepository
{
    Task<bool> ExistsAsync(int lessonId, CancellationToken cancellationToken);
    Task<Lesson?> GetByIdAsync(int lessonId, CancellationToken cancellationToken);
    Task<List<Lesson>> GetRangeAsync(int? userId, string? searchTerm, CancellationToken cancellationToken);
}
