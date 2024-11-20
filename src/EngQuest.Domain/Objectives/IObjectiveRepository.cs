namespace EngQuest.Domain.Objectives;

public interface IObjectiveRepository
{
    Task<Objective?> GetByIdAsync(int objectiveId, int questId, CancellationToken cancellationToken);
    Task<Objective?> GetRandomAsync(int questId, CancellationToken cancellationToken);
}