using Polyglot.Domain.Abstractions;

namespace Polyglot.Domain.Exercises;

public static class ExerciseErrors
{
    public static readonly Error NotFound = new("Exercise.NotFound", "Exercise was not found.");
    public static readonly Error EmptyRusPhrase = new("Exercise.EmptyRusPhrase", "Rus phrase can't be empty.");
    public static readonly Error LessonAlreadyAdded = new("Exercise.LessonAlreadyAdded", "Lesson already added.");
}
