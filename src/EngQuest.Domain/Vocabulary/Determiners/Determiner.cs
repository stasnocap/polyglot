using EngQuest.Domain.Shared;
using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Vocabulary.Determiners;

public sealed class Determiner
{
    public int Id { get; init; }
    public Text Text { get; }

    public Determiner(Text text)
    {
        Text = text;
    }
    
    // ReSharper disable once UnusedMember.Local
    private Determiner()
    {
    }
}
