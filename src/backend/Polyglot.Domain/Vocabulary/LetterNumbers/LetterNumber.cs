using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.LetterNumbers;

public sealed class LetterNumber
{
    public int Id { get; init; }
    public Text Text { get; }
    public Number Number { get; }

    public LetterNumber(Text text, Number number)
    {
        Text = text;
        Number = number;
    }

    // ReSharper disable once UnusedMember.Local
    private LetterNumber()
    {
    }
}
