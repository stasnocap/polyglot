using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Adjectives;

public sealed class Adjective : Entity
{
    public Text Text { get; private set; }

    public Adjective(Guid id, Text text) : base(id)
    {
        Text = text;
    }

    // ReSharper disable once UnusedMember.Local
    private Adjective()
    {
    }

    public void SetText(Text text)
    {
        Text = text;
    }
}
