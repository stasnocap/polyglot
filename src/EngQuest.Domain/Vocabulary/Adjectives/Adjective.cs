using EngQuest.Domain.Abstractions;
using EngQuest.Domain.Shared;

namespace EngQuest.Domain.Vocabulary.Adjectives;

public sealed class Adjective : Entity
{
    public Text Text { get; private set; }

    public Adjective(Text text)
    {
        Text = text;
    }

    // ReSharper disable once UnusedMember.Local
    private Adjective()
    {
    }

    public void SetText(Text text)
    {
        Text = text;
    }
}
