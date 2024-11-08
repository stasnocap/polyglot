using Microsoft.EntityFrameworkCore;
using Polyglot.Domain.Lessons.Exercises;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.LetterNumbers;
using Polyglot.Infrastructure.Extensions;

namespace Polyglot.Infrastructure.Repositories.Vocabulary;

public class LetterNumberRepository(ApplicationDbContext _dbContext)
{
    public async Task<List<string>> GetRandomLetterNumbersAsync(Word word, int count, CancellationToken cancellationToken)
    {
        Text? wordText = word.Text.GetWord();

        LetterNumber? letterNumber = await _dbContext
            .Set<LetterNumber>()
            .AsNoTracking()
            .Where(ln => wordText == ln.Text)
            .FirstOrDefaultAsync(cancellationToken);

        double halfOfACount = Math.Ceiling(count / 2.0);

        List<LetterNumber> letterNumbers = await _dbContext
            .Set<LetterNumber>()
            .AsNoTracking()
            .OrderBy(ln => Guid.NewGuid())
            .WhereIf(letterNumber is not null, ln => ln.Id != letterNumber!.Id
                                                     && letterNumber.Number.Value - halfOfACount <= (int)ln.Number && (int)ln.Number <= letterNumber.Number.Value + halfOfACount)
            .Take(count)
            .ToListAsync(cancellationToken);

        if (letterNumbers.Count < count)
        {
            var retrievedLetterNumberIds = letterNumbers.Select(ln => ln.Id).ToList();

            letterNumbers.AddRange(await _dbContext
                .Set<LetterNumber>()
                .AsNoTracking()
                .OrderBy(ln => Guid.NewGuid())
                .Where(ln => !retrievedLetterNumberIds.Contains(ln.Id))
                .Take(count - letterNumbers.Count)
                .ToListAsync(cancellationToken));
        }

        return letterNumbers.Select(ln => ln.Text.Value).ToList();
    }
}
