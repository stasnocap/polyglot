using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.ModalVerbs;

public sealed class ModalVerb : Entity
{
    public Text Text { get; }
    public FullNegativeForm FullNegativeForm { get; }
    public ShortNegativeForm ShortNegativeForm { get; }

    public ModalVerb(Guid id, Text text, FullNegativeForm fullNegativeForm, ShortNegativeForm shortNegativeForm) : base(id)
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
