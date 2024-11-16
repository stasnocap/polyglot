using EngQuest.Application.Abstractions.Messaging;
using EngQuest.Domain.Abstractions;
using EngQuest.Domain.Quests;

namespace EngQuest.Application.Objectives.GetObjective;

public class GetObjectiveQueryHandler(IQuestRepository _questRepository, ObjectiveConverter _objectiveConverter) : IQueryHandler<GetObjectiveQuery, ObjectiveResponse>
{
    public async Task<Result<ObjectiveResponse>> Handle(GetObjectiveQuery request, CancellationToken cancellationToken)
    {
        Quest? quest = await _questRepository.GetByIdAsync(request.QuestId, cancellationToken);

        if (quest is null)
        {
            return Result.Failure<ObjectiveResponse>(QuestErrors.NotFound);
        }

        QuestObjective? objective = quest.Objectives.FirstOrDefault(x => x.ObjectiveId == request.ObjectiveId);

        if (objective is null)
        {
            return Result.Failure<ObjectiveResponse>(QuestErrors.ObjectiveNotFound);
        }

        ObjectiveResponse objectiveResponse = await _objectiveConverter.ConvertAsync(objective.Objective, quest, cancellationToken);

        return objectiveResponse;
    }
}
