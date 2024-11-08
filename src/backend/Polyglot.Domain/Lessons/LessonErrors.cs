using Polyglot.Domain.Abstractions;

namespace Polyglot.Domain.Lessons;

public static class LessonErrors
{
    public static readonly Error NotFound = new(
        "Lesson.NotFound",
        "Lesson was not found");
    
    public static readonly Error ExerciseNotFound = new(
        "Lesson.ExerciseNotFound",
        "Exercise was not found");
    
    public static readonly Error ExerciseAlreadyExists = new(
        "Lesson.ExerciseAlreadyExists",
        "Such exercise already exists");
    
    public static readonly Error ExerciseWordsAreEmpty = new(
        "Lesson.ExerciseWordsAreEmpty",
        "Exercise words can't be empty");
}
