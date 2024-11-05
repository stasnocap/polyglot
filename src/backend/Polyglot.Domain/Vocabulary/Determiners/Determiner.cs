using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Determiners;

public sealed class Determiner : Entity
{
    public Text Text { get; }

    public Determiner(Guid id, Text text) : base(id)
    {
        Text = text;
    }
    
    // ReSharper disable once UnusedMember.Local
    private Determiner()
    {
    }
}
