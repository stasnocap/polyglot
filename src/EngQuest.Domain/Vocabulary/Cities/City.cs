using EngQuest.Domain.Shared;

namespace EngQuest.Domain.Vocabulary.Cities;

public sealed class City
{
    public int Id { get; init; }
    public Text Text { get; }

    public City(Text text)
    {
        Text = text;
    }

    // ReSharper disable once UnusedMember.Local
    private City()
    {
    }
}
