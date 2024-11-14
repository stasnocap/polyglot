using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.Nouns;

namespace EngQuest.Domain.UnitTests.Vocabulary.Nouns;

internal static class NounData
{
    public static readonly Text Text = new("ball");
    public const NounType NounType = EngQuest.Domain.Vocabulary.Nouns.NounType.RegularNoun;
}
