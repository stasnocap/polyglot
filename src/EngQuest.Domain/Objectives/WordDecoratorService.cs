using System.Text.RegularExpressions;

namespace EngQuest.Domain.Objectives;

public static class WordDecoratorService
{
    public static void Decorate(Word word, List<string> words)
    {
        Match match = Regex.Match(word.Text.Value, @"^\w+(\W)$");
        if (match.Success)
        {
            AppendSymbol(words, match.Groups[1].Value);
        }
    }

    private static void AppendSymbol(List<string> words, string symbol)
    {
        for (int i = 0; i < words.Count; i++)
        {
            string wordStr = words[i];
            words[i] = $"{wordStr}{symbol}";
        }
    }
}
