using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Verbs;

public sealed record ThirdPersonForm(string Value)
{
    private static readonly IReadOnlyCollection<string> EsEndings = ["ch", "s", "sh", "x", "z"];
    
    public static implicit operator string(ThirdPersonForm form) => form.Value;

    public static bool Is(Text text)
    {
        return text.Value.EndsWith('s');
    }

    public static ThirdPersonForm From(Text verbText)
    {
        string value = GenerateThirdPersonForm(verbText);

        return new ThirdPersonForm(value);
    }

    private static string GenerateThirdPersonForm(Text text)
    {
        string textValue = text.Value;
        
        if (textValue == "go")
        {
            return "goes";
        }

        string lastTwoChars = textValue[^2..];

        if (EsEndings.Any(textValue.EndsWith))
        {
            return textValue + "es";
        }

        if (Letters.Consonants.Contains(lastTwoChars[0]) && lastTwoChars[1] == 'y')
        {
            return textValue[..^1] + "ies";
        }

        return textValue + 's';
    }
}
