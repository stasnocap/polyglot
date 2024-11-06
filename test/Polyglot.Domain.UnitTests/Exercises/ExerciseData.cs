using Polyglot.Domain.Exercises;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.UnitTests.Exercises;

internal static class ExerciseData
{
    public static readonly Guid LessonId = Guid.Parse("6e7135dc-1553-492c-a3b8-33997f3bd493");
    
    public static readonly RusPhrase RusPhrase = new("Тест фраза");

    public static readonly IReadOnlyCollection<Word> Words =
    [
        new(WordData.Id, WordData.ExerciseId, WordData.WordNumber, WordData.Text, WordData.WordType),
        new(2, Guid.NewGuid(), new WordNumber(2), new Text("adverb"), WordType.Adverb),
        new(3, Guid.NewGuid(), new WordNumber(3), new Text("city"), WordType.City),
    ];
}
