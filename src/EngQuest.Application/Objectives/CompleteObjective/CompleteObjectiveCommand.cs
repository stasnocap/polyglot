using EngQuest.Application.Abstractions.Messaging;
using EngQuest.Domain.Quests;

namespace EngQuest.Application.Objectives.CompleteObjective;

public record CompleteObjectiveCommand(int ObjectiveId, int QuestId, string Answer) : ICommand<CompleteObjectiveResult>;
