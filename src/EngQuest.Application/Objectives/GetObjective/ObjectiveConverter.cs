using System.Diagnostics.CodeAnalysis;
using EngQuest.Application.Abstractions.Authentication;
using EngQuest.Domain.Quests;
using EngQuest.Domain.Quests.Objectives;
using EngQuest.Domain.Quests.Scores;
using EngQuest.Domain.Vocabulary;

namespace EngQuest.Application.Objectives.GetObjective;

public class ObjectiveConverter(
    IVocabularyRepository _vocabularyRepository,
    IUserContext _userContext)
{
    private const int WordGroupSize = 6;
    private const int RightAnswerCount = 1;
    private const int RandomWordsCount = WordGroupSize - RightAnswerCount;

    [SuppressMessage("Security", "CA5394:Do not use insecure randomness")]
    public async Task<ObjectiveResponse> ConvertAsync(Objective objective, Quest quest, CancellationToken cancellationToken)
    {
        List<string[]> wordGroups = [];

        foreach (Word word in objective.Words.OrderBy(x => x.Number.Value))
        {
            List<string> words = await _vocabularyRepository.GetRandomAsync(word, RandomWordsCount, cancellationToken);

            WordDecoratorService.Decorate(word, words);

            words.Insert(Random.Shared.Next(words.Count), word.Text.Value);

            wordGroups.Add([..words]);
        }

        int? currentUserId = _userContext.UserId;

        Score? score = quest.Scores.FirstOrDefault(x => x.UserId == currentUserId);

        return new ObjectiveResponse
        {
            ObjectiveId = objective.Id,
            QuestId = quest.Id,
            RusPhrase = objective.RusPhrase.Value,
            WordGroups = [..wordGroups],
            RatingCorrectNumber = score?.Rating.CorrectNumber,
            RatingWrongNumber = score?.Rating.WrongNumber,
            RatingRate = score?.Rating.Rate,
        };
    }
}
