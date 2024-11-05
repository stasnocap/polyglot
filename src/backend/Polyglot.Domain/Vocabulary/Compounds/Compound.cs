using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Compounds;

public sealed class Compound : Entity
{
    public Text Text { get; }
    public CompoundType Type { get; }

    public Compound(Guid id, Text text, CompoundType type) : base(id)
    {
        Text = text;
        Type = type;
    }
    
    // ReSharper disable once UnusedMember.Local
    private Compound()
    {
    }
}
