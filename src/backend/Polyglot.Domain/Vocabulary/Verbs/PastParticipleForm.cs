using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Verbs;

public sealed record PastParticipleForm(string Value)
{
    public static bool Is(Text text)
    {
        return text.Value.EndsWith("ed", StringComparison.InvariantCulture);
    }
}
