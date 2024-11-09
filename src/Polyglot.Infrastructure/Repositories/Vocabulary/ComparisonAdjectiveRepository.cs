using Microsoft.EntityFrameworkCore;
using Polyglot.Domain.Lessons.Exercises;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.ComparisonAdjectives;
using Polyglot.Infrastructure.Extensions;

namespace Polyglot.Infrastructure.Repositories.Vocabulary;

public class ComparisonAdjectiveRepository(ApplicationDbContext _dbContext)
{
    public async Task<List<string>> GetRandomComparisonAdjectivesAsync(Word word, int count, CancellationToken cancellationToken)
    {
        Text wordText = word.Text.GetWord();

        ComparisonAdjective? comparisonAdjective = await _dbContext.Set<ComparisonAdjective>()
            .FirstOrDefaultAsync(ca => wordText == ca.Text
                                       || (string)wordText == (string)ca.ComparativeForm
                                       || (string)wordText == (string)ca.SuperlativeForm, cancellationToken);

        List<ComparisonAdjective> comparisonAdjectives = await _dbContext
            .Set<ComparisonAdjective>()
            .WhereIf(comparisonAdjective is not null, ca => ca.Id != comparisonAdjective!.Id)
            .OrderBy(ca => Guid.NewGuid())
            .Take(count)
            .ToListAsync(cancellationToken);

        if (comparisonAdjective is not null)
        {
            if (wordText == comparisonAdjective.Text)
            {
                return comparisonAdjectives.Select(ca => ca.Text.Value).ToList();
            }

            if (wordText.Value == comparisonAdjective.ComparativeForm.Value)
            {
                return comparisonAdjectives.Select(ca => ca.ComparativeForm.Value).ToList();
            }

            if (wordText.Value == comparisonAdjective.SuperlativeForm.Value)
            {
                return comparisonAdjectives.Select(ca => ca.SuperlativeForm.Value).ToList();
            }
        }
        else
        {
            if (ComparativeForm.Is(wordText))
            {
                return comparisonAdjectives.Select(ca => ca.ComparativeForm.Value).ToList();
            }

            if (SuperlativeForm.Is(wordText))
            {
                return comparisonAdjectives.Select(ca => ca.SuperlativeForm.Value).ToList();
            }

            return comparisonAdjectives.Select(ca => ca.Text.Value).ToList();
        }

        throw new ApplicationException();
    }
}
