using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using EngQuest.Application.Abstractions.Data;
using EngQuest.Application.Abstractions.Messaging;
using EngQuest.Application.Extensions;
using EngQuest.Application.Objectives.GetObjective;
using EngQuest.Domain.Abstractions;
using EngQuest.Domain.Objectives;
using EngQuest.Domain.Quests;
using EngQuest.Domain.Vocabulary;

namespace EngQuest.Application.Objectives.GetRandomObjective;

public class GetRandomObjectiveQueryHandler(
    ISqlConnectionFactory _sqlConnectionFactory,
    IVocabularyRepository _vocabularyRepository,
    IObjectiveRepository _objectiveRepository) : IQueryHandler<GetRandomObjectiveQuery, ObjectiveResponse>
{
    private const int WordGroupSize = 6;
    private const int RightAnswerCount = 1;
    private const int RandomWordsCount = WordGroupSize - RightAnswerCount;

    public async Task<Result<ObjectiveResponse>> Handle(GetRandomObjectiveQuery request, CancellationToken cancellationToken)
    {
        Objective? randomObjective = await _objectiveRepository.GetRandomAsync(request.QuestId, cancellationToken);

        if (randomObjective is null)
        {
            return Result.Failure<ObjectiveResponse>(QuestErrors.NotFound);
        }

        using IDbConnection dbConnection = _sqlConnectionFactory.CreateConnection();

        List<string[]> wordGroups = [];

        foreach (Word word in randomObjective.Words.OrderBy(x => x.Number.Value))
        {
            List<string> words = await _vocabularyRepository.GetRandomAsync(word, RandomWordsCount, dbConnection, cancellationToken);

            WordDecoratorService.Decorate(word, words);

            words.Insert(Random.Shared.Next(words.Count), word.Text.Value.ToLower(CultureInfo.InvariantCulture));

            wordGroups.Add([..words]);
        }

        wordGroups.Shuffle(count: 4);

        return new ObjectiveResponse
        {
            ObjectiveId = randomObjective.Id,
            QuestId = request.QuestId,
            RusPhrase = randomObjective.RusPhrase.Value,
            WordGroups = [..wordGroups],
        };
    }
}
