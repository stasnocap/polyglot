using System.Globalization;
using System.Text.RegularExpressions;

namespace Polyglot.Domain.Shared;

public sealed record Text(string Value)
{
    public Text GetWord()
    {
        Match match = Regex.Match(Value, @"([mM]ore |[mM]ost |\d )?[a-zA-Z0-9'-]+( not\b)?");

        string word = match.Value.ToLower(CultureInfo.GetCultureInfo("en-US"));

        return new Text(word);
    }
}
