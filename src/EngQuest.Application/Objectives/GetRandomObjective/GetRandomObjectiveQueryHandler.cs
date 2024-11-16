using System.Diagnostics.CodeAnalysis;
using EngQuest.Application.Abstractions.Messaging;
using EngQuest.Application.Objectives.GetObjective;
using EngQuest.Domain.Abstractions;
using EngQuest.Domain.Quests;

namespace EngQuest.Application.Objectives.GetRandomObjective;

[SuppressMessage("Security", "CA5394:Do not use insecure randomness")]
public class GetRandomObjectiveQueryHandler(IQuestRepository _questRepository, ObjectiveConverter _objectiveConverter) : IQueryHandler<GetRandomObjectiveQuery, ObjectiveResponse>
{
    public async Task<Result<ObjectiveResponse>> Handle(GetRandomObjectiveQuery request, CancellationToken cancellationToken)
    {
        Quest? quest = await _questRepository.GetByIdAsync(request.QuestId, cancellationToken);

        if (quest is null)
        {
            return Result.Failure<ObjectiveResponse>(QuestErrors.NotFound);
        }
        
        QuestObjective questObjective = quest.Objectives[Random.Shared.Next(quest.Objectives.Count)];

        ObjectiveResponse objectiveResult = await _objectiveConverter.ConvertAsync(questObjective.Objective, quest, cancellationToken);

        return objectiveResult;
    }
}
