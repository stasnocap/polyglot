namespace Polyglot.Domain.Exercises;

public sealed record WordNumber(int Value)
{
    public static implicit operator int(WordNumber number) => number.Value;
};
