using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Pronouns;

public sealed class Pronoun : Entity
{
    public Text Text { get; }
    public PronounType Type { get; }

    public Pronoun(Guid id, Text text, PronounType type) : base(id)
    {
        Text = text;
        Type = type;
    }

    // ReSharper disable once UnusedMember.Local
    private Pronoun()
    {
    }
}
