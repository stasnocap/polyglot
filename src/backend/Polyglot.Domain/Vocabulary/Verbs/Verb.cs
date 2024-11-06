using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Verbs;

public sealed class Verb : Entity
{
    public Text Text { get; }
    public PastForm PastForm { get; }
    public PastParticipleForm PastParticipleForm { get; }
    public PresentParticipleForm PresentParticipleForm { get; }
    public ThirdPersonForm ThirdPersonForm { get; }
    public IsIrregularVerb IsIrregularVerb { get; }

    public Verb(Guid id, Text text, PastForm pastForm, PastParticipleForm pastParticipleForm, PresentParticipleForm presentParticipleForm, ThirdPersonForm thirdPersonForm, IsIrregularVerb isIrregularVerb) : base(id)
    {
        Text = text;
        PastForm = pastForm;
        PastParticipleForm = pastParticipleForm;
        PresentParticipleForm = presentParticipleForm;
        ThirdPersonForm = thirdPersonForm;
        IsIrregularVerb = isIrregularVerb;
    }

    // ReSharper disable once UnusedMember.Local
    private Verb()
    {
    }

    public static Verb CreateIrregularVerb(Text text, PastForm pastForm, PastParticipleForm pastParticipleForm)
    {
        return CreateIrregularVerb(Guid.NewGuid(), text, pastForm, pastParticipleForm);
    }

    public static Verb CreateIrregularVerb(Guid verbId, Text text, PastForm pastForm, PastParticipleForm pastParticipleForm)
    {
        var presentParticipleForm = PresentParticipleForm.From(text, stressOnFinalSyllable: true);
        var thirdPersonForm = ThirdPersonForm.From(text);
        return new Verb(verbId, text, pastForm, pastParticipleForm, presentParticipleForm, thirdPersonForm, new IsIrregularVerb(true));
    }
}
