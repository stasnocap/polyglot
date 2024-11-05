using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Prepositions;

public sealed class Preposition : Entity
{
    public Text Text { get; }

    public Preposition(Guid id, Text text) : base(id)
    {
        Text = text;
    }

    // ReSharper disable once UnusedMember.Local
    private Preposition()
    {
    }
}
