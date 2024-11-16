using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using Dapper;
using Microsoft.EntityFrameworkCore;
using EngQuest.Application.Abstractions.Data;
using EngQuest.Domain.Quests.Objectives;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary;
using EngQuest.Infrastructure.Data;

namespace EngQuest.Infrastructure.Repositories.Vocabulary;

[SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out")]
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
        // IDbConnection connection = _sqlConnectionFactory.CreateConnection();

        switch (word.Type)
        {
            case WordType.Adjective:
            case WordType.City:
            case WordType.Determiner:
            case WordType.Language:
            case WordType.Preposition:
            case WordType.QuestionWord:
                Type wordType = WordTypes.GetWordType(word.Type);

                // string wordText = word.Text.GetWord();
                // string tableName = TableNames.GetTableName(word.Type);
                // const string sql = """
                //               SELECT text FROM @TableName
                //               WHERE text != @Word
                //               ORDER BY random()
                //               LIMIT @Count
                //               """;
                //
                // var words = await connection.QueryAsync(sql, new { TableName = tableName, Word = wordText, Count = count });

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
