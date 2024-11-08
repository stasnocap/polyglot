namespace Polyglot.Domain.Lessons;

public interface ILessonRepository
{
    Task<bool> ExistsAsync(int lessonId, CancellationToken cancellationToken);
    Task<Lesson?> GetAsync(int lessonId, CancellationToken cancellationToken);
    Task<List<Lesson>> GetRangeAsync(int? userId, string? searchTerm, CancellationToken cancellationToken);
}
