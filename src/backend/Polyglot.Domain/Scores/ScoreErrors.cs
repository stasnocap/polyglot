using Polyglot.Domain.Abstractions;

namespace Polyglot.Domain.Scores;

public static class ScoreErrors
{
    public static readonly Error NegativeCorrectNumber = new($"{nameof(Score)}.{nameof(NegativeCorrectNumber)}", "Correct number can't be negative.");
    public static readonly Error NegativeWrongNumber = new($"{nameof(Score)}.{nameof(NegativeWrongNumber)}", "Wrong number can't be negative.");
}
