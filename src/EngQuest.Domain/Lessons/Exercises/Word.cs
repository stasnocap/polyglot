using Shared_Text = EngQuest.Domain.Shared.Text;
using Text = EngQuest.Domain.Shared.Text;

namespace EngQuest.Domain.Lessons.Exercises;

public sealed class Word
{
    public int Id { get; init; }
    
    public WordNumber Number { get; }
    public Shared_Text Text { get; }
    public WordType Type { get; }

    public Word(WordNumber number, Shared_Text text, WordType type)
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
