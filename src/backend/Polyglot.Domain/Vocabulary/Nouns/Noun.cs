using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Nouns;

public sealed class Noun : Entity
{
    public Text Text { get; }
    public PluralForm PluralForm { get; }
    public NounType Type { get; }

    public Noun(Guid id, Text text, PluralForm pluralForm, NounType type) : base(id)
    {
        Text = text;
        PluralForm = pluralForm;
        Type = type;
    }

    // ReSharper disable once UnusedMember.Local
    private Noun()
    {
    }

    public static Noun Create(Text text, NounType type)
    {
        return Create(Guid.NewGuid(), text, type);
    }

    public static Noun Create(Guid nounId, Text text, NounType type)
    {
        var pluralForm = PluralForm.From(text);
        
        return new Noun(nounId, text, pluralForm, type);
    }
}
