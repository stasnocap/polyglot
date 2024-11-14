namespace EngQuest.Domain.Vocabulary.LetterNumbers;

public sealed record Number(int Value)
{
    public static implicit operator int(Number number) => number.Value;
};
