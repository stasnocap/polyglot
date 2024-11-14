using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.ModalVerbs;
using EngQuest.Domain.Vocabulary.Verbs;
using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Vocabulary.PrimaryVerbs;

public sealed class PrimaryVerb
{
    private readonly List<FullNegativeForm> _fullNegativeForms = [];
    private readonly List<ShortNegativeForm> _shortNegativeForms = [];
    private readonly List<AdditionalForm> _additionalForms = [];

    public int Id { get; init; }
    
    public Text Text { get; }
    public PastForm PastForm { get; }
    public PastParticipleForm PastParticipleForm { get; }
    public PresentParticipleForm PresentParticipleForm { get; }
    public ThirdPersonForm ThirdPersonForm { get; }
    
    public IReadOnlyList<FullNegativeForm> FullNegativeForms => [.._fullNegativeForms];
    public IReadOnlyList<ShortNegativeForm> ShortNegativeForms => [.._shortNegativeForms];
    public IReadOnlyList<AdditionalForm> AdditionalForms => [.._additionalForms];

    public PrimaryVerb(
        Text text,
        PastForm pastForm,
        PastParticipleForm pastParticipleForm,
        PresentParticipleForm presentParticipleForm,
        ThirdPersonForm thirdPersonForm)
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
