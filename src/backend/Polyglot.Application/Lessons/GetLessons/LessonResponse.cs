namespace Polyglot.Application.Lessons.GetLessons;

public sealed class LessonResponse
{
    public required Guid LessonId { get; init; }
    public required int Number { get; init; }
    public required string Name { get; init; }
    public float? Rate { get; init; }
}
