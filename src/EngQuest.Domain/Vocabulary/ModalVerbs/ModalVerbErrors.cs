using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Vocabulary.ModalVerbs;

public static class ModalVerbErrors
{
    public static readonly Error EmptyFullNegativeForm = new("ModalVerb.EmptyFullNegativeForm", "Full negative form can't be empty.");
    public static readonly Error EmptyShortNegativeForm = new("ModalVerb.EmptyShortNegativeForm", "Short negative form can't be empty.");
}
