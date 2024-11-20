using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Quests;

public static class QuestErrors
{
    public static readonly Error NotFound = new(
        "Quest.NotFound",
        "Quest was not found");
    
}
