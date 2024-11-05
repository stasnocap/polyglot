using Text = Polyglot.Domain.Shared.Text;

namespace Polyglot.Domain.Exercises;

public sealed class Word
{
    public int Id { get; }
    public Guid ExerciseId { get; }
    public WordNumber Number { get; }
    public Text Text { get; }
    public WordType Type { get; }

    public Word(int id, Guid exerciseId, WordNumber number, Text text, WordType type)
    {
        Id = id;
        Number = number;
        Text = text;
        Type = type;
        ExerciseId = exerciseId;
    }

    // ReSharper disable once UnusedMember.Local
    private Word()
    {
    }
}
