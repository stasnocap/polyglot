using Microsoft.EntityFrameworkCore;
using Polyglot.Domain.Exercises;
using Polyglot.Domain.Vocabulary.Adverbs;
using Polyglot.Infrastructure.Extensions;

namespace Polyglot.Infrastructure.Repositories.Vocabulary;

public class AdverbRepository(ApplicationDbContext _dbContext)
{
    public async Task<List<string>> GetRandomAdverbsAsync(Word word, int count, CancellationToken cancellationToken)
    {
        Adverb? adverb = await _dbContext
            .Set<Adverb>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => word.Text.GetWord() == a.Text, cancellationToken);

        List<Adverb> adverbs = await _dbContext
            .Set<Adverb>()
            .AsNoTracking()
            .WhereIf(adverb is not null, a => a.Type == adverb!.Type && a.Id != adverb.Id)
            .OrderBy(a => Guid.NewGuid())
            .Take(count)
            .ToListAsync(cancellationToken);

        return adverbs.Select(x => x.Text.Value).ToList();
    }
}
