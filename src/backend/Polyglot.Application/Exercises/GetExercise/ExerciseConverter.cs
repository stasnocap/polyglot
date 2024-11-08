using System.Diagnostics.CodeAnalysis;
using Polyglot.Application.Abstractions.Authentication;
using Polyglot.Domain.Lessons;
using Polyglot.Domain.Lessons.Exercises;
using Polyglot.Domain.Lessons.Scores;
using Polyglot.Domain.Vocabulary;

namespace Polyglot.Application.Exercises.GetExercise;

public class ExerciseConverter(
    IVocabularyRepository _vocabularyRepository,
    IUserContext _userContext)
{
    private const int WordGroupSize = 6;
    private const int RightAnswerCount = 1;
    private const int RandomWordsCount = WordGroupSize - RightAnswerCount;

    [SuppressMessage("Security", "CA5394:Do not use insecure randomness")]
    public async Task<ExerciseResponse> ConvertAsync(Exercise exercise, Lesson lesson, CancellationToken cancellationToken)
    {
        List<string[]> wordGroups = [];

        foreach (Word word in exercise.Words.OrderBy(x => x.Number.Value))
        {
            List<string> words = await _vocabularyRepository.GetRandomAsync(word, RandomWordsCount, cancellationToken);

            WordDecoratorService.Decorate(word, words);

            words.Insert(Random.Shared.Next(words.Count), word.Text.Value);

            wordGroups.Add([..words]);
        }

        int? currentUserId = _userContext.UserId;

        Score? score = lesson.Scores.FirstOrDefault(x => x.UserId == currentUserId);

        return new ExerciseResponse
        {
            ExerciseId = exercise.Id,
            LessonId = lesson.Id,
            RusPhrase = exercise.RusPhrase.Value,
            WordGroups = [..wordGroups],
            RatingCorrectNumber = score?.Rating.CorrectNumber,
            RatingWrongNumber = score?.Rating.WrongNumber,
            RatingRate = score?.Rating.Rate,
        };
    }
}
