using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Verbs;

public sealed class Verb
{
    public int Id { get; init; }
    public Text Text { get; }
    public PastForm PastForm { get; }
    public PastParticipleForm PastParticipleForm { get; }
    public PresentParticipleForm PresentParticipleForm { get; }
    public ThirdPersonForm ThirdPersonForm { get; }
    public IsIrregularVerb IsIrregularVerb { get; }

    public Verb(Text text, PastForm pastForm, PastParticipleForm pastParticipleForm, PresentParticipleForm presentParticipleForm, ThirdPersonForm thirdPersonForm, IsIrregularVerb isIrregularVerb)
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

    public static Verb CreateIrregularVerb(int verbId, Text text, PastForm pastForm, PastParticipleForm pastParticipleForm)
    {
        var presentParticipleForm = PresentParticipleForm.From(text, stressOnFinalSyllable: true);
        var thirdPersonForm = ThirdPersonForm.From(text);
        return new Verb(text, pastForm, pastParticipleForm, presentParticipleForm, thirdPersonForm, new IsIrregularVerb(true))
        {
            Id = verbId
        };
    }
}
