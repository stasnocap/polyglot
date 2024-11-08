using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Nouns;

public sealed class Noun
{
    public int Id { get; init; }
    public Text Text { get; }
    public PluralForm PluralForm { get; }
    public NounType Type { get; }

    public Noun(Text text, PluralForm pluralForm, NounType type)
    {
        Text = text;
        PluralForm = pluralForm;
        Type = type;
    }

    // ReSharper disable once UnusedMember.Local
    private Noun()
    {
    }

    public static Noun Create(int nounId, Text text, NounType type)
    {
        var pluralForm = PluralForm.From(text);
        
        return new Noun(text, pluralForm, type)
        {
            Id = nounId
        };
    }
}
