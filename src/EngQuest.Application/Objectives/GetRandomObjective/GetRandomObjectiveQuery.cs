using EngQuest.Application.Abstractions.Messaging;
using EngQuest.Application.Objectives.GetObjective;

namespace EngQuest.Application.Objectives.GetRandomObjective;

public record GetRandomObjectiveQuery(int QuestId) : IQuery<ObjectiveResponse>;
