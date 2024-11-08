using Microsoft.EntityFrameworkCore;
using Polyglot.Domain.Lessons.Exercises;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.Nouns;
using Polyglot.Infrastructure.Extensions;

namespace Polyglot.Infrastructure.Repositories.Vocabulary;

public class NounRepository(ApplicationDbContext _dbContext)
{
    public async Task<List<string>> GetRandomNounsAsync(Word word, int count, CancellationToken cancellationToken)
    {
        Text? wordText = word.Text.GetWord();

        Noun? noun = await _dbContext.Set<Noun>()
            .FirstOrDefaultAsync(n => wordText == n.Text || (string)wordText == (string)n.PluralForm
                , cancellationToken);

        List<Noun> nouns = await _dbContext
            .Set<Noun>()
            .AsNoTracking()
            .WhereIf(noun is not null, n => n.Id != noun!.Id)
            .OrderBy(n => Guid.NewGuid())
            .Take(count)
            .ToListAsync(cancellationToken);

        if (noun is not null)
        {
            if (wordText == noun.Text)
            {
                return nouns.Select(n => n.Text.Value).ToList();
            }

            if ((string)wordText == (string)noun.PluralForm)
            {
                return nouns.Select(n => n.PluralForm.Value).ToList();
            }
        }
        else
        {
            if (PluralForm.Is(word.Text))
            {
                return nouns.Select(n => n.PluralForm.Value).ToList();
            }

            return nouns.Select(n => n.Text.Value).ToList();
        }

        throw new ApplicationException();
    }
}
