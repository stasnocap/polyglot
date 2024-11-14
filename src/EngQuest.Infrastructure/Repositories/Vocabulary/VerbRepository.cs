using Microsoft.EntityFrameworkCore;
using EngQuest.Domain.Lessons.Exercises;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.Verbs;
using EngQuest.Infrastructure.Extensions;

namespace EngQuest.Infrastructure.Repositories.Vocabulary;

public class VerbRepository(ApplicationDbContext _dbContext)
{
    public async Task<List<string>> GetRandomVerbsAsync(Word word, int count, CancellationToken cancellationToken)
    {
        Text? wordText = word.Text.GetWord();

        Verb? verb = await _dbContext.Set<Verb>()
            .FirstOrDefaultAsync(v => wordText == v.Text
                                       || (string)wordText == (string)v.PastForm
                                       || (string)wordText == (string)v.PastParticipleForm
                                       || (string)wordText == (string)v.PresentParticipleForm
                                       || (string)wordText == (string)v.ThirdPersonForm
                , cancellationToken);

        List<Verb> verbs = await _dbContext
            .Set<Verb>()
            .AsNoTracking()
            .WhereIf(verb is not null, v => v.Id != verb!.Id)
            .OrderBy(v => Guid.NewGuid())
            .Take(count)
            .ToListAsync(cancellationToken);

        if (verb is not null)
        {
            if (wordText == verb.Text)
            {
                return verbs.Select(v => v.Text.Value).ToList();
            }

            if ((string)wordText == (string)verb.PastForm)
            {
                return verbs.Select(v => v.PastForm.Value).ToList();
            }

            if ((string)wordText == (string)verb.PastParticipleForm)
            {
                return verbs.Select(v => v.PastParticipleForm.Value).ToList();
            }

            if ((string)wordText == (string)verb.PresentParticipleForm)
            {
                return verbs.Select(v => v.PresentParticipleForm.Value).ToList();
            }

            if ((string)wordText == (string)verb.ThirdPersonForm)
            {
                return verbs.Select(v => v.ThirdPersonForm.Value).ToList();
            }
        }
        else
        {
            if (PastForm.Is(word.Text))
            {
                return verbs.Select(v => v.PastForm.Value).ToList();
            }

            if (PastParticipleForm.Is(word.Text))
            {
                return verbs.Select(v => v.PastParticipleForm.Value).ToList();
            }

            if (PresentParticipleForm.Is(word.Text))
            {
                return verbs.Select(v => v.PresentParticipleForm.Value).ToList();
            }

            if (ThirdPersonForm.Is(word.Text))
            {
                return verbs.Select(v => v.ThirdPersonForm.Value).ToList();
            }

            return verbs.Select(v => v.Text.Value).ToList();
        }

        throw new ApplicationException();
    }
}
