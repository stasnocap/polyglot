using Polyglot.Domain.Lessons.Exercises;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.UnitTests.Lessons.Exercises;

internal static class WordData
{
    public static readonly WordNumber WordNumber = new(1);
    
    public static readonly Text Text = new("adjective");

    public const WordType WordType = Domain.Lessons.Exercises.WordType.Adjective;
}
