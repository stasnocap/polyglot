using Polyglot.Domain.Lessons;

namespace Polyglot.Domain.UnitTests.Lessons;

internal static class LessonData
{
    public static readonly LessonName LessonName = new("Lesson Name");
    public static readonly Guid ExerciseId = Guid.Parse("02b6f148-943f-443d-89e2-ae1cda1e6426");
    public static readonly Guid ScoreId = Guid.Parse("9fc6d1e0-f320-46e3-a0c9-50299d78550d");
}
