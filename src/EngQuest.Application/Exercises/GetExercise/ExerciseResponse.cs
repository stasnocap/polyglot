namespace EngQuest.Application.Exercises.GetExercise;

public sealed class ExerciseResponse
{
    public required int ExerciseId { get; init; }
    
    public required int LessonId { get; init; }
    
    public required string RusPhrase { get; init; }
    
    public required string[][] WordGroups { get; init; }
    
    public int? RatingCorrectNumber { get; init; }
    
    public int? RatingWrongNumber { get; init; }
    
    public float? RatingRate { get; init; }
}
