using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.ModalVerbs;
using Polyglot.Domain.Vocabulary.Verbs;

namespace Polyglot.Domain.Vocabulary.PrimaryVerbs;

public sealed class PrimaryVerb : Entity
{
    private readonly List<FullNegativeForm> _fullNegativeForms = [];
    private readonly List<ShortNegativeForm> _shortNegativeForms = [];
    private readonly List<AdditionalForm> _additionalForms = [];

    public Text Text { get; }
    public PastForm PastForm { get; }
    public PastParticipleForm PastParticipleForm { get; }
    public PresentParticipleForm PresentParticipleForm { get; }
    public ThirdPersonForm ThirdPersonForm { get; }
    
    public IReadOnlyCollection<FullNegativeForm> FullNegativeForms => [.._fullNegativeForms];
    public IReadOnlyCollection<ShortNegativeForm> ShortNegativeForms => [.._shortNegativeForms];
    public IReadOnlyCollection<AdditionalForm> AdditionalForms => [.._additionalForms];

    public PrimaryVerb(Guid id,
        Text text,
        PastForm pastForm,
        PastParticipleForm pastParticipleForm,
        PresentParticipleForm presentParticipleForm,
        ThirdPersonForm thirdPersonForm) : base(id)
    {
        Text = text;
        PastForm = pastForm;
        PastParticipleForm = pastParticipleForm;
        PresentParticipleForm = presentParticipleForm;
        ThirdPersonForm = thirdPersonForm;
    }

    // ReSharper disable once UnusedMember.Local
    private PrimaryVerb()
    {
    }
}
