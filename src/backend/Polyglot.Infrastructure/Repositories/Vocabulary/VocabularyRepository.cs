using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Polyglot.Domain.Exercises;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary;

namespace Polyglot.Infrastructure.Repositories.Vocabulary;

public class VocabularyRepository(
    ApplicationDbContext _dbContext,
    ComparisonAdjectiveRepository comparisonAdjectiveRepository,
    LetterNumberRepository _letterNumberRepository,
    ModalVerbRepository _modalVerbRepository,
    NounRepository _nounRepository,
    PrimaryVerbRepository _primaryVerbRepository,
    AdverbRepository _adverbRepository,
    CompoundRepository _compoundRepository,
    VerbRepository _verbRepository,
    NumberWithNounRepository _numberWithNounRepository,
    PronounRepository _pronounRepository) : IVocabularyRepository
{
    public async Task<List<string>> GetRandomAsync(Word word, int count, CancellationToken cancellationToken)
    {
        switch (word.Type)
        {
            case WordType.Adjective:
            case WordType.City:
            case WordType.Determiner:
            case WordType.Language:
            case WordType.Preposition:
            case WordType.QuestionWord:
                Type wordType = WordTypes.GetWordType(word.Type);

                List<object> words = await _dbContext.GetAll(wordType)
                    .AsNoTracking()
                    .Where(w => word.Text.GetWord() != EF.Property<Text>(w, "Text"))
                    .OrderBy(w => Guid.NewGuid())
                    .Take(count)
                    .ToListAsync(cancellationToken);

                PropertyInfo textProperty = wordType.GetProperty("Text")!;

                return words.Select(x => ((Text)textProperty.GetValue(x)!).Value).ToList();
            case WordType.Adverb:
                return await _adverbRepository.GetRandomAdverbsAsync(word, count, cancellationToken);
            case WordType.Compound:
                return await _compoundRepository.GetRandomCompoundsAsync(word, count, cancellationToken);
            case WordType.ComparisonAdjective:
                return await comparisonAdjectiveRepository.GetRandomComparisonAdjectivesAsync(word, count, cancellationToken);
            case WordType.LetterNumber:
                return await _letterNumberRepository.GetRandomLetterNumbersAsync(word, count, cancellationToken);
            case WordType.ModalVerb:
                return await _modalVerbRepository.GetRandomModalVerbsAsync(word, count, cancellationToken);
            case WordType.Noun:
                return await _nounRepository.GetRandomNounsAsync(word, count, cancellationToken);
            case WordType.PrimaryVerb:
                return await _primaryVerbRepository.GetRandomPrimaryVerbsAsync(word, count, cancellationToken);
            case WordType.Verb:
                return await _verbRepository.GetRandomVerbsAsync(word, count, cancellationToken);
            case WordType.NumberWithNoun:
                return await _numberWithNounRepository.GetRandomNumberWithNounsAsync(word, count, cancellationToken);
            case WordType.Pronoun:
                return await _pronounRepository.GetRandomPronounsAsync(word, count, cancellationToken);
            case WordType.None:
            default:
                throw new ApplicationException();
        }
    }
}
