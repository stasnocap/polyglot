using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Cities;

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
