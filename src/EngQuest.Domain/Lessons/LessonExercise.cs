using EngQuest.Domain.Lessons.Exercises;

namespace EngQuest.Domain.Lessons;

public sealed class LessonExercise
{
    public int LessonId { get; init; }

    public int ExerciseId { get; init; }

    public Exercise Exercise { get; init; }
}
