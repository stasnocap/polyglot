namespace Polyglot.Domain.Lessons;

public interface ILessonRepository
{
    Task<bool> ExistsAsync(Guid lessonId, CancellationToken cancellationToken);
    Task<LessonNumber?> GetLessonNumberAsync(Guid lessonId, CancellationToken cancellationToken);
    Task<Lesson?> GetAsync(Guid lessonId, CancellationToken cancellationToken);
    Task<List<Lesson>> GetRangeAsync(Guid? userId, string? searchTerm, CancellationToken cancellationToken);
}
