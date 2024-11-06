using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.NumberWithNouns;

public sealed class NumberWithNoun : Entity
{
    public Text Text { get; }

    public NumberWithNoun(Guid id, Text text) : base(id)
    {
        Text = text;
    }

    // ReSharper disable once UnusedMember.Local
    private NumberWithNoun()
    {
    }
}
