using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.ModalVerbs;

public sealed class ModalVerb
{
    public int Id { get; init; }
    public Text Text { get; }
    public FullNegativeForm FullNegativeForm { get; }
    public ShortNegativeForm ShortNegativeForm { get; }

    public ModalVerb(Text text, FullNegativeForm fullNegativeForm, ShortNegativeForm shortNegativeForm)
    {
        Text = text;
        FullNegativeForm = fullNegativeForm;
        ShortNegativeForm = shortNegativeForm;
    }

    // ReSharper disable once UnusedMember.Local
    private ModalVerb()
    {
    }
}
