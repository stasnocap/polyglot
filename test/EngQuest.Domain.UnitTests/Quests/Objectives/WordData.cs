using EngQuest.Domain.Quests.Objectives;
using EngQuest.Domain.Shared;

namespace EngQuest.Domain.UnitTests.Quests.Objectives;

internal static class WordData
{
    public static readonly WordNumber WordNumber = new(1);
    
    public static readonly Text Text = new("adjective");

    public const WordType WordType = EngQuest.Domain.Quests.Objectives.WordType.Adjective;
}
