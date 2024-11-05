using Polyglot.Domain.Abstractions;

namespace Polyglot.Domain.Lessons;

public static class LessonErrors
{
    public static readonly Error EmptyName = new("Lesson.EmptyName", "Lesson name can't be empty.");
    public static readonly Error NegativeNumber = new("Lesson.NegativeNumber", "Lesson number can't be negative or zero.");
    public static readonly Error NotFound = new($"Lesson.NotFound", "Lesson was not found");
    public static readonly Error ExerciseAlreadyAdded = new("Lesson.ExerciseAlreadyAdded", "Exercise already added.");
    public static readonly Error ScoreAlreadyAdded = new("Lesson.ScoreAlreadyAdded", "Score already added.");
}
