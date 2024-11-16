using Microsoft.EntityFrameworkCore;
using EngQuest.Domain.Quests.Objectives;
using EngQuest.Domain.Vocabulary.Compounds;
using EngQuest.Infrastructure.Extensions;

namespace EngQuest.Infrastructure.Repositories.Vocabulary;

public class CompoundRepository(ApplicationDbContext _dbContext)
{
    public async Task<List<string>> GetRandomCompoundsAsync(Word word, int count, CancellationToken cancellationToken)
    {
        Compound? compound = await _dbContext
            .Set<Compound>()
            .AsNoTracking()
            .FirstOrDefaultAsync(c => word.Text.GetWord() == c.Text, cancellationToken);

        List<Compound> compounds = await _dbContext
            .Set<Compound>()
            .AsNoTracking()
            .WhereIf(compound is not null, c => c.Type == compound!.Type && c.Id != compound.Id)
            .OrderBy(a => Guid.NewGuid())
            .Take(count)
            .ToListAsync(cancellationToken);

        if (compounds.Count < count)
        {
            var retrievedCompoundIds = compounds.Select(c => c.Id).ToList();
            
            compounds.AddRange(await _dbContext.Set<Compound>()
                .AsNoTracking()
                .Where(c => !retrievedCompoundIds.Contains(c.Id))
                .WhereIf(compound is not null, c => c.Id != compound!.Id)
                .OrderBy(a => Guid.NewGuid())
                .Take(count - compounds.Count)
                .ToListAsync(cancellationToken));
        }

        return compounds.Select(x => x.Text.Value).ToList();
    }
}
