using EngQuest.Domain.Quests.Objectives;

namespace EngQuest.Domain.Quests;

public sealed class QuestObjective
{
    public int QuestId { get; init; }

    public int ObjectiveId { get; init; }

    public Objective Objective { get; init; }
}
