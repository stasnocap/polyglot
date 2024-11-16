using System.Text.RegularExpressions;
using EngQuest.Domain.Quests.Objectives;

namespace EngQuest.Infrastructure.Repositories.Vocabulary;

public class NumberWithNounRepository(NounRepository _nounRepository)
{
    public async Task<List<string>> GetRandomNumberWithNounsAsync(Word word, int count, CancellationToken cancellationToken)
    {
        List<string> nouns = await _nounRepository.GetRandomNounsAsync(word, count, cancellationToken);
        
        string? number = Regex.Match(word.Text.Value, @"\d+").Value;

        return nouns.Select(n => $"{number} {n}").ToList();
    }
}
