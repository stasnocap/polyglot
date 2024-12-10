﻿using System.Data;
using Dapper;
using EngQuest.Domain.Objectives;
using Microsoft.EntityFrameworkCore;
using EngQuest.Domain.Vocabulary.Adverbs;
using EngQuest.Infrastructure.Extensions;

namespace EngQuest.Infrastructure.Repositories.Vocabulary;

public class AdverbRepository
{
    public async Task<List<string>> GetRandomAdverbsAsync(Word word, int count, IDbConnection dbConnection, CancellationToken cancellationToken)
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
