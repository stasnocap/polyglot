using Polyglot.Domain.Lessons.Exercises;

namespace Polyglot.Domain.Lessons;

public sealed class LessonExercise
{
    public int LessonId { get; init; }

    public int ExerciseId { get; init; }

    public Exercise Exercise { get; init; }
}
