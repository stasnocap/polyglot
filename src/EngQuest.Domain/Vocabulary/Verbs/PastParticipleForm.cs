using EngQuest.Domain.Shared;

namespace EngQuest.Domain.Vocabulary.Verbs;

public sealed record PastParticipleForm(string Value)
{
    public static implicit operator string(PastParticipleForm form) => form.Value;
    
    public static bool Is(Text text)
    {
        return text.Value.EndsWith("ed", StringComparison.InvariantCulture);
    }
}
