using Text = Polyglot.Domain.Shared.Text;

namespace Polyglot.Domain.Lessons.Exercises;

public sealed class Word
{
    public int Id { get; init; }
    
    public WordNumber Number { get; }
    public Text Text { get; }
    public WordType Type { get; }

    public Word(WordNumber number, Text text, WordType type)
    {
        Number = number;
        Text = text;
        Type = type;
    }

    // ReSharper disable once UnusedMember.Local
    private Word()
    {
    }
}
