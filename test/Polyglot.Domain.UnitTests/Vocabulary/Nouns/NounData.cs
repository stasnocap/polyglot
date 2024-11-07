using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.Nouns;

namespace Polyglot.Domain.UnitTests.Vocabulary.Nouns;

internal static class NounData
{
    public static readonly Text Text = new("ball");
    public const NounType NounType = Domain.Vocabulary.Nouns.NounType.RegularNoun;
}