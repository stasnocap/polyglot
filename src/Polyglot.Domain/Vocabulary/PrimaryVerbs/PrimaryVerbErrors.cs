using Polyglot.Domain.Abstractions;

namespace Polyglot.Domain.Vocabulary.PrimaryVerbs;

public static class PrimaryVerbErrors
{
    public static readonly Error EmptyAdditionalForm = new("ModalVerb.EmptyAdditionalForm", "Additional form can't be empty.");
}
