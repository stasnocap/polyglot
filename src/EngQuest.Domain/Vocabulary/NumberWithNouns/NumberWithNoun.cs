using EngQuest.Domain.Shared;

namespace EngQuest.Domain.Vocabulary.NumberWithNouns;

public sealed class NumberWithNoun
{
    public int Id { get; init; }
    public Text Text { get; }

    public NumberWithNoun(Text text)
    {
        Text = text;
    }

    // ReSharper disable once UnusedMember.Local
    private NumberWithNoun()
    {
    }
}
