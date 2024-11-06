using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.LetterNumbers;

public sealed class LetterNumber : Entity
{
    public Text Text { get; }
    public Number Number { get; }

    public LetterNumber(Guid id, Text text, Number number) : base(id)
    {
        Text = text;
        Number = number;
    }

    // ReSharper disable once UnusedMember.Local
    private LetterNumber()
    {
    }
}
