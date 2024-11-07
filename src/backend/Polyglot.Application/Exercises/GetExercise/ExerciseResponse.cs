namespace Polyglot.Application.Exercises.GetExercise;

public sealed class ExerciseResponse
{
    public required Guid ExerciseId { get; init; }
    
    public required int LessonNumber { get; init; }
    
    public required string RusPhrase { get; init; }
    
    public required string[][] WordGroups { get; init; }
    
    public int? RatingCorrectNumber { get; init; }
    
    public int? RatingWrongNumber { get; init; }
    
    public float? RatingRate { get; init; }
}
