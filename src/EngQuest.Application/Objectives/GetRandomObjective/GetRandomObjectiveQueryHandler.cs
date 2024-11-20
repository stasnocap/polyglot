using System.Diagnostics.CodeAnalysis;
using EngQuest.Application.Abstractions.Messaging;
using EngQuest.Application.Objectives.GetObjective;
using EngQuest.Domain.Abstractions;
using EngQuest.Domain.Objectives;
using EngQuest.Domain.Quests;
using EngQuest.Domain.Vocabulary;

namespace EngQuest.Application.Objectives.GetRandomObjective;

public class GetRandomObjectiveQueryHandler(
    IVocabularyRepository _vocabularyRepository,
    IObjectiveRepository _objectiveRepository) : IQueryHandler<GetRandomObjectiveQuery, ObjectiveResponse>
{
    private const int WordGroupSize = 6;
    private const int RightAnswerCount = 1;
    private const int RandomWordsCount = WordGroupSize - RightAnswerCount;

    [SuppressMessage("Security", "CA5394:Do not use insecure randomness")]
    public async Task<Result<ObjectiveResponse>> Handle(GetRandomObjectiveQuery request, CancellationToken cancellationToken)
    {
        Objective? randomObjective = await _objectiveRepository.GetRandomAsync(request.QuestId, cancellationToken);

        if (randomObjective is null)
        {
            return Result.Failure<ObjectiveResponse>(QuestErrors.NotFound);
        }

        List<string[]> wordGroups = [];

        foreach (Word word in randomObjective.Words.OrderBy(x => x.Number.Value))
        {
            List<string> words = await _vocabularyRepository.GetRandomAsync(word, RandomWordsCount, cancellationToken);

            WordDecoratorService.Decorate(word, words);

            words.Insert(Random.Shared.Next(words.Count), word.Text.Value);

            wordGroups.Add([..words]);
        }

        return new ObjectiveResponse
        {
            ObjectiveId = randomObjective.Id,
            QuestId = request.QuestId,
            RusPhrase = randomObjective.RusPhrase.Value,
            WordGroups = [..wordGroups],
        };
    }
}
