using Microsoft.EntityFrameworkCore;
using EngQuest.Domain.Quests.Objectives;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.PrimaryVerbs;
using EngQuest.Infrastructure.Extensions;

namespace EngQuest.Infrastructure.Repositories.Vocabulary;

public class PrimaryVerbRepository(ApplicationDbContext _dbContext)
{
    public async Task<List<string>> GetRandomPrimaryVerbsAsync(Word word, int count, CancellationToken cancellationToken)
    {
        Text? wordText = word.Text.GetWord();

        PrimaryVerb? primaryVerb = await _dbContext.Set<PrimaryVerb>()
            .FirstOrDefaultAsync(pv => wordText == pv.Text
                                       || (string)wordText == (string)pv.PastForm
                                       || (string)wordText == (string)pv.PastParticipleForm
                                       || (string)wordText == (string)pv.PresentParticipleForm
                                       || (string)wordText == (string)pv.ThirdPersonForm
                                       || pv.FullNegativeForms.Any(fnf => fnf.Value == wordText.Value)
                                       || pv.ShortNegativeForms.Any(snf => snf.Value == wordText.Value)
                                       || pv.AdditionalForms.Any(af => af.Value == wordText.Value)
                , cancellationToken);

        List<PrimaryVerb> primaryVerbs = await _dbContext
            .Set<PrimaryVerb>()
            .AsNoTracking()
            .WhereIf(primaryVerb is not null, pv => pv.Id != primaryVerb!.Id)
            .OrderBy(pv => Guid.NewGuid())
            .Take(count)
            .ToListAsync(cancellationToken);

        if (primaryVerb is not null)
        {
            if (wordText == primaryVerb.Text)
            {
                return await GetTexts(primaryVerbs, count, cancellationToken);
            }

            if ((string)wordText == (string)primaryVerb.PastForm)
            {
                var pastForms = primaryVerbs.Select(pv => pv.PastForm.Value).ToList();

                await AddTextsIfNotFilledUp(pastForms, count, cancellationToken);
                
                return pastForms;
            }

            if ((string)wordText == (string)primaryVerb.PastParticipleForm)
            {
                var pastParticipleForms = primaryVerbs.Select(pv => pv.PastParticipleForm.Value).ToList();

                await AddTextsIfNotFilledUp(pastParticipleForms, count, cancellationToken);
                
                return pastParticipleForms;
            }

            if ((string)wordText == (string)primaryVerb.PresentParticipleForm)
            {
                var presentParticipleForms = primaryVerbs.Select(pv => pv.PresentParticipleForm.Value).ToList();

                await AddTextsIfNotFilledUp(presentParticipleForms, count, cancellationToken);
                
                return presentParticipleForms;
            }

            if ((string)wordText == (string)primaryVerb.ThirdPersonForm)
            {
                var thirdPersonForms = primaryVerbs.Select(pv => pv.ThirdPersonForm.Value).ToList();

                await AddTextsIfNotFilledUp(thirdPersonForms, count, cancellationToken);
                
                return thirdPersonForms;
            }

            if (primaryVerb.FullNegativeForms.Any(fnf => (string)wordText == (string)fnf))
            {
                var fullNegativeForms = primaryVerb.FullNegativeForms
                    .Where(fnf => fnf.Value != wordText.Value)
                    .Select(fnf => fnf.Value).ToList();

                if (fullNegativeForms.Count < count)
                {
                    fullNegativeForms.AddRange(primaryVerbs
                        .SelectMany(pv => pv.FullNegativeForms.Select(af => af.Value))
                        .OrderBy(_ => Guid.NewGuid())
                        .Take(count - fullNegativeForms.Count));
                }
                
                return fullNegativeForms;
            }

            if (primaryVerb.ShortNegativeForms.Any(snf => (string)wordText == (string)snf))
            {
                var shortNegativeForms = primaryVerb.ShortNegativeForms
                    .Where(fnf => fnf.Value != wordText.Value)
                    .Select(fnf => fnf.Value).ToList();

                if (shortNegativeForms.Count < count)
                {
                    shortNegativeForms.AddRange(primaryVerbs
                        .SelectMany(pv => pv.ShortNegativeForms.Select(af => af.Value))
                        .OrderBy(_ => Guid.NewGuid())
                        .Take(count - shortNegativeForms.Count));
                }
                
                return shortNegativeForms;
            }

            if (primaryVerb.AdditionalForms.Any(af => (string)wordText == (string)af))
            {                
                var additionalForms = primaryVerb.AdditionalForms
                    .Where(fnf => fnf.Value != wordText.Value)
                    .Select(fnf => fnf.Value).ToList();

                await AddTextsIfNotFilledUp(additionalForms, count, cancellationToken);
                
                return additionalForms;
            }
        }

        return await GetTexts(primaryVerbs, count, cancellationToken);
    }

    private async Task AddTextsIfNotFilledUp(List<string> forms, int count, CancellationToken cancellationToken)
    {
        if (forms.Count < count)
        {
            forms.AddRange(await _dbContext.Set<PrimaryVerb>()
                .AsNoTracking()
                .Select(pv => pv.Text.Value)
                .OrderBy(pv => Guid.NewGuid())
                .Take(count - forms.Count)
                .ToListAsync(cancellationToken));
        }
    }

    private async Task<List<string>> GetTexts(List<PrimaryVerb> primaryVerbs, int count, CancellationToken cancellationToken)
    {
        var texts = primaryVerbs.Select(pv => pv.Text.Value).ToList();

        if (texts.Count < count)
        {
            texts.AddRange(await _dbContext.Set<PrimaryVerb>()
                .AsNoTracking()
                .Select(pv => pv.PastForm.Value)
                .Take(count - texts.Count)
                .ToListAsync(cancellationToken));
        }
                
        return texts;
    }
}
