using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Vocabulary.Verbs;

public static class VerbErrors
{
    public static readonly Error EmptyVerbText = new("Verb.EmptyText", "Verb text can't be empty.");
    public static readonly Error EmptyPastForm = new("Verb.EmptyPastForm", "Past form can't be empty.");
    public static readonly Error EmptyPastParticipleForm = new("Verb.EmptyPastParticipleForm", "Past participle form can't be empty.");
    public static readonly Error EmptyPresentParticipleForm = new("Verb.EmptyPresentParticipleForm", "Present participle form can't be empty.");
    public static readonly Error EmptyThirdPersonForm = new("Verb.EmptyThirdPersonForm", "Third person form can't be empty.");
}
