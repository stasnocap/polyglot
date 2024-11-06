using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Languages;

public sealed class Language : Entity
{
    public Text Text { get; }

    public Language(Guid id, Text text) : base(id)
    {
        Text = text;
    }
    
    // ReSharper disable once UnusedMember.Local
    private Language()
    {
    }
}
