namespace Polyglot.Application.Lessons.GetLessons;

public sealed class LessonResponse
{
    public required int LessonId { get; init; }
    public required string Name { get; init; }
    public float? Rate { get; init; }
}
