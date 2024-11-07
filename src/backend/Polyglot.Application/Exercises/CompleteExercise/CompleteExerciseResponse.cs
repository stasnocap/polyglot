namespace Polyglot.Application.Exercises.CompleteExercise;

public record CompleteExerciseResponse
{
    public required bool Success { get; init; }
    
    public required string CorrectAnswer { get; init; }
    
    public required Guid ExerciseId { get; init; }
}
