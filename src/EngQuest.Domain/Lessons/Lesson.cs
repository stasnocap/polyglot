using EngQuest.Domain.Abstractions;
using EngQuest.Domain.Lessons.Exercises;
using EngQuest.Domain.Lessons.Scores;

namespace EngQuest.Domain.Lessons;

public sealed class Lesson
{
    private readonly List<LessonExercise> _exercises = [];
    private readonly List<Score> _scores = [];

    public int Id { get; init; }
    public LessonName Name { get; }

    public IReadOnlyList<LessonExercise> Exercises => [.._exercises];
    public IReadOnlyList<Score> Scores => [.._scores];

    public Lesson(LessonName name)
    {
        Name = name;
    }

    // ReSharper disable once UnusedMember.Local
    private Lesson()
    {
    }

    public Result AddExercise(Exercise exercise)
    {
        if (exercise.Words.Count == 0)
        {
            return Result.Failure(LessonErrors.ExerciseWordsAreEmpty);
        }

        if (_exercises.Exists(x => x.Exercise.RusPhrase == exercise.RusPhrase))
        {
            return Result.Failure(LessonErrors.ExerciseAlreadyExists);
        }

        _exercises.Add(new LessonExercise
        {
            LessonId = Id,
            Exercise = exercise,
        });

        return Result.Success();
    }

    public Result<CompleteExerciseResult> CompleteExercise(string answer, int exerciseId, int? userId)
    {
        LessonExercise? lessonExercise = _exercises.Find(x => x.ExerciseId == exerciseId);

        if (lessonExercise is null)
        {
            return Result.Failure<CompleteExerciseResult>(LessonErrors.ExerciseNotFound);
        }

        string correctAnswer = string.Join(' ', lessonExercise.Exercise.Words.Select(x => x.Text.Value));

        bool isCorrectAnswer = correctAnswer == answer;

        var completeExerciseResult = new CompleteExerciseResult
        {
            Success = isCorrectAnswer,
            CorrectAnswer = correctAnswer,
        };

        if (userId is null)
        {
            return Result.Success(completeExerciseResult);
        }

        Score? score = _scores.Find(x => x.UserId == userId);

        score ??= new Score(Rating.Init(), userId.Value);

        if (correctAnswer == answer)
        {
            score.Rating.Increase();
        }
        else
        {
            score.Rating.Decrease();
        }

        return Result.Success(completeExerciseResult);
    }
}
