using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Prepositions;

public sealed class Preposition
{
    public int Id { get; init; }
    public Text Text { get; }

    public Preposition(Text text)
    {
        Text = text;
    }

    // ReSharper disable once UnusedMember.Local
    private Preposition()
    {
    }
}
