using EngQuest.Application.Abstractions.Messaging;

namespace EngQuest.Application.Objectives.GetObjective;

public record GetObjectiveQuery(int ObjectiveId, int QuestId) : IQuery<ObjectiveResponse>;
