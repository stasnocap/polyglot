namespace EngQuest.Application.Quests.GetQuests;

public sealed class QuestResponse
{
    public required int QuestId { get; init; }
    public required string Name { get; init; }
    public float? Rate { get; init; }
}
