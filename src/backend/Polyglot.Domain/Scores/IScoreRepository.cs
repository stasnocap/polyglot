namespace Polyglot.Domain.Scores;

public interface IScoreRepository
{
    Task<Score?> GetAsync(Guid lessonId, Guid userId, CancellationToken cancellationToken);
    void Add(Score score);
}
