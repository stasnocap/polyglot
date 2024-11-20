namespace EngQuest.Domain.Objectives;

public sealed record WordNumber(int Value)
{
    public static implicit operator int(WordNumber number) => number.Value;
};
