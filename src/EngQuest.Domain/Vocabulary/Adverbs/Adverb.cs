using EngQuest.Domain.Shared;

namespace EngQuest.Domain.Vocabulary.Adverbs;

public sealed class Adverb
{
    public int Id { get; init; }
    public Text Text { get; }
    public AdverbType Type { get; }

    public Adverb(Text text, AdverbType type)
    {
        Text = text;
        Type = type;
    }

    // ReSharper disable once UnusedMember.Local
    private Adverb()
    {
    }
}
