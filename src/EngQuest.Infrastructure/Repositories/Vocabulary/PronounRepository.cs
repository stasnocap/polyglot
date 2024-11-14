using Microsoft.EntityFrameworkCore;
using EngQuest.Domain.Lessons.Exercises;
using EngQuest.Domain.Vocabulary.Pronouns;
using EngQuest.Infrastructure.Extensions;

namespace EngQuest.Infrastructure.Repositories.Vocabulary;

public class PronounRepository(ApplicationDbContext _dbContext)
{
    public async Task<List<string>> GetRandomPronounsAsync(Word word, int count, CancellationToken cancellationToken)
    {
        Pronoun? pronoun = await _dbContext
            .Set<Pronoun>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => word.Text.GetWord() == a.Text, cancellationToken);

        List<Pronoun> pronouns = await _dbContext
            .Set<Pronoun>()
            .AsNoTracking()
            .WhereIf(pronoun is not null, a => a.Type == pronoun!.Type && a.Id != pronoun.Id)
            .OrderBy(a => Guid.NewGuid())
            .Take(count)
            .ToListAsync(cancellationToken);

        if (pronouns.Count < count)
        {
            var retrievedPronounIds = pronouns.Select(p => p.Id).ToList();
            
            pronouns.AddRange(await _dbContext
                .Set<Pronoun>()
                .AsNoTracking()
                .Where(p => !retrievedPronounIds.Contains(p.Id))
                .WhereIf(pronoun is not null, a => a.Id != pronoun!.Id)
                .OrderByDescending(p => Guid.NewGuid())
                .Take(count - pronouns.Count)
                .ToListAsync(cancellationToken));
        }

        return pronouns.Select(x => x.Text.Value).ToList();
    }
}
