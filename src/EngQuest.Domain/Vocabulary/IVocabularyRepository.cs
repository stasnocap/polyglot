using System.Linq.Expressions;
using EngQuest.Domain.Quests.Objectives;
using EngQuest.Domain.Shared;

namespace EngQuest.Domain.Vocabulary;

public interface IVocabularyRepository
{
    Task<List<string>> GetRandomAsync(Word word, int count, CancellationToken cancellationToken);
}
