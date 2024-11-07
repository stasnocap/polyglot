using Polyglot.Domain.Exercises;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.UnitTests.Exercises;

internal static class WordData
{
    public static Guid ExerciseId = Guid.Parse("b63827ec-a7b1-4299-b9b7-5e9b788d8c2e");

    public const int Id = 1;
    
    public static readonly WordNumber WordNumber = new(1);
    
    public static readonly Text Text = new("adjective");

    public const WordType WordType = Domain.Exercises.WordType.Adjective;
}
