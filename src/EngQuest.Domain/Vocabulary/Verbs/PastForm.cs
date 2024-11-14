using EngQuest.Domain.Shared;

namespace EngQuest.Domain.Vocabulary.Verbs;

public sealed record PastForm(string Value)
{
    public static implicit operator string(PastForm pastForm) => pastForm.Value;
    
    public static bool Is(Text text)
    {
        return text.Value.EndsWith("ed", StringComparison.InvariantCulture);
    }

    public static PastForm From(Text verbText, bool stressOnFinalSyllable)
    {
        string value = GeneratePastForm(verbText.Value, stressOnFinalSyllable);

        return new PastForm(value);
    }

    private static string GeneratePastForm(string text, bool stressOnFinalSyllable)
    {
        switch (text)
        {
            case "ship":
                return "shipped";
            case "chew":
                return "chewed";
            case "relax":
                return "relaxed";
        }

        string lastTwoChars = text[^2..];

        if (stressOnFinalSyllable && Letters.Vowels.Contains(lastTwoChars[0]) && Letters.Consonants.Contains(lastTwoChars[1]))
        {
            return text + lastTwoChars[1] + "ed";
        }

        if (Letters.Vowels.Contains(lastTwoChars[0]) && text.EndsWith('y'))
        {
            return text + "ed";
        }

        if (text.EndsWith('y'))
        {
            return text[..^1] + "ied";
        }

        if (text.EndsWith('e'))
        {
            return text + 'd';
        }

        return text + "ed";
    }
}
