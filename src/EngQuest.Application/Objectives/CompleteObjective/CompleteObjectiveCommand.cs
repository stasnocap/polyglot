using EngQuest.Application.Abstractions.Authorization;
using EngQuest.Domain.Objectives;

namespace EngQuest.Application.Objectives.CompleteObjective;

public record CompleteObjectiveCommand(int ObjectiveId, int QuestId, string Answer) : IAuthorizedForQuestRequest<CompleteObjectiveResponse>;
