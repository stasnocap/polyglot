using EngQuest.Application.Abstractions.Authorization;
using EngQuest.Application.Objectives.GetObjective;

namespace EngQuest.Application.Objectives.GetRandomObjective;

public record GetRandomObjectiveQuery(int QuestId) : IAuthorizedForQuestRequest<ObjectiveResponse>;
