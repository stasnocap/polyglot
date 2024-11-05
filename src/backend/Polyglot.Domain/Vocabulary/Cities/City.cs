using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Cities;

public sealed class City : Entity
{
    public Text Text { get; }

    public City(Guid id, Text text) : base(id)
    {
        Text = text;
    }

    // ReSharper disable once UnusedMember.Local
    private City()
    {
    }
}
