using EngQuest.Domain.Shared;

namespace EngQuest.Domain.Vocabulary.Verbs;

public sealed record PresentParticipleForm(string Value)
{
    public static implicit operator string(PresentParticipleForm presentParticipleForm) => presentParticipleForm.Value;
    
    public static bool Is(Text text)
    {
        return text.Value.EndsWith("ing", StringComparison.InvariantCulture);
    }

    public static PresentParticipleForm From(Text verbText, bool stressOnFinalSyllable)
    {
        string value = GeneratePresentParticipleForm(verbText, stressOnFinalSyllable);

        return new PresentParticipleForm(value);
    }

    private static string GeneratePresentParticipleForm(Text text, bool stressOnFinalSyllable)
    {
        string textValue = text.Value;
        
        string lastTwoChars = textValue[^2..];

        if (stressOnFinalSyllable && Letters.Vowels.Contains(lastTwoChars[0]) && Letters.Consonants.Contains(lastTwoChars[1]))
        {
            return textValue + lastTwoChars[1] + "ing";
        }

        if (textValue.EndsWith("ie", StringComparison.InvariantCulture))
        {
            return textValue[..^2] + 'y' + "ing";
        }

        if (textValue.EndsWith('e'))
        {
            return textValue[..^1] + "ing";
        }

        return textValue + "ing";
    }
}
