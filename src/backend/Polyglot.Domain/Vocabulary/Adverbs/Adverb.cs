using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Adverbs;

public sealed class Adverb : Entity
{
    public Text Text { get; }
    public AdverbType Type { get; }

    public Adverb(Guid id, Text text, AdverbType type) : base(id)
    {
        Text = text;
        Type = type;
    }

    // ReSharper disable once UnusedMember.Local
    private Adverb()
    {
    }
}
