namespace Polyglot.Domain.Exercises;

public interface IExerciseRepository
{
    Task<Exercise> GetRandomAsync(Guid lessonId, CancellationToken cancellationToken);
    Task<Exercise?> GetAsync(Guid exerciseId, CancellationToken cancellationToken);
    Task<string?> GetAnswerAsync(Guid exerciseId, CancellationToken cancellationToken);
}
