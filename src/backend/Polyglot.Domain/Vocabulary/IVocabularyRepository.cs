using System.Linq.Expressions;
using Polyglot.Domain.Exercises;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary;

public interface IVocabularyRepository
{
    Task<List<string>> GetRandomAsync(Word word, int count, CancellationToken cancellationToken);
}
