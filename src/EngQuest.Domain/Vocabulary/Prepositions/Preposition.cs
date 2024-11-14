using EngQuest.Domain.Shared;
using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Vocabulary.Prepositions;

public sealed class Preposition
{
    public int Id { get; init; }
    public Text Text { get; }

    public Preposition(Text text)
    {
        Text = text;
    }

    // ReSharper disable once UnusedMember.Local
    private Preposition()
    {
    }
}
