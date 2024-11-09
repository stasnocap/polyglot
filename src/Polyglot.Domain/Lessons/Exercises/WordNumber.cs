namespace Polyglot.Domain.Lessons.Exercises;

public sealed record WordNumber(int Value)
{
    public static implicit operator int(WordNumber number) => number.Value;
};
