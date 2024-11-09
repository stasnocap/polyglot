using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.ModalVerbs;

public sealed record FullNegativeForm(string Value)
{
    public static implicit operator string(FullNegativeForm form) => form.Value;
    
    public static bool Is(Text text)
    {
        return text.Value.EndsWith("not", StringComparison.InvariantCulture);
    }
}
