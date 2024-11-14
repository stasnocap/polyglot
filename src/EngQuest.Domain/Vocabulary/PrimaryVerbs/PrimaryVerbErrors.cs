using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Vocabulary.PrimaryVerbs;

public static class PrimaryVerbErrors
{
    public static readonly Error EmptyAdditionalForm = new("ModalVerb.EmptyAdditionalForm", "Additional form can't be empty.");
}
