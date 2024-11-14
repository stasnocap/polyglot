using System.Linq.Expressions;
using EngQuest.Domain.Lessons.Exercises;
using EngQuest.Domain.Shared;

namespace EngQuest.Domain.Vocabulary;

public interface IVocabularyRepository
{
    Task<List<string>> GetRandomAsync(Word word, int count, CancellationToken cancellationToken);
}
