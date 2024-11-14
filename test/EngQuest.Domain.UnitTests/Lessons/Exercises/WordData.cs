using EngQuest.Domain.Lessons.Exercises;
using EngQuest.Domain.Shared;

namespace EngQuest.Domain.UnitTests.Lessons.Exercises;

internal static class WordData
{
    public static readonly WordNumber WordNumber = new(1);
    
    public static readonly Text Text = new("adjective");

    public const WordType WordType = EngQuest.Domain.Lessons.Exercises.WordType.Adjective;
}
