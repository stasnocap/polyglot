using Microsoft.EntityFrameworkCore;
using Polyglot.Domain.Lessons.Exercises;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.ModalVerbs;
using Polyglot.Infrastructure.Extensions;

namespace Polyglot.Infrastructure.Repositories.Vocabulary;

public class ModalVerbRepository(ApplicationDbContext _dbContext)
{
    public async Task<List<string>> GetRandomModalVerbsAsync(Word word, int count, CancellationToken cancellationToken)
    {
        Text? wordText = word.Text.GetWord();

        ModalVerb? modalVerb = await _dbContext.Set<ModalVerb>()
            .FirstOrDefaultAsync(mv => wordText == mv.Text
                                       || (string)wordText == (string)mv.FullNegativeForm
                                       || (string)wordText == (string)mv.ShortNegativeForm, cancellationToken);

        List<ModalVerb> modalVerbs = await _dbContext
            .Set<ModalVerb>()
            .WhereIf(modalVerb is not null, mv => mv.Id != modalVerb!.Id)
            .OrderBy(mv => Guid.NewGuid())
            .Take(count)
            .ToListAsync(cancellationToken);

        if (modalVerb is not null)
        {
            if (wordText == modalVerb.Text)
            {
                return modalVerbs.Select(mv => mv.Text.Value).ToList();
            }

            if ((string)wordText == (string)modalVerb.FullNegativeForm)
            {
                return modalVerbs.Select(mv => mv.FullNegativeForm.Value).ToList();
            }

            if ((string)wordText == (string)modalVerb.ShortNegativeForm)
            {
                return modalVerbs.Select(mv => mv.ShortNegativeForm.Value).ToList();
            }
        }
        else
        {
            if (FullNegativeForm.Is(word.Text))
            {
                return modalVerbs.Select(mv => mv.FullNegativeForm.Value).ToList();
            }

            if (ShortNegativeForm.Is(word.Text))
            {
                return modalVerbs.Select(mv => mv.ShortNegativeForm.Value).ToList();
            }

            return modalVerbs.Select(mv => mv.Text.Value).ToList();
        }

        throw new ApplicationException();
    }
}
