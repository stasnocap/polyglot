using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Lessons.Exercises;
using Polyglot.Domain.Lessons.Scores;

namespace Polyglot.Domain.Lessons;

public sealed class Lesson
{
    private readonly List<Exercise> _exercises = [];
    private readonly List<Score> _scores = [];

    public short Id { get; init; }
    public LessonName Name { get; }

    public IReadOnlyList<Exercise> Exercises => [.._exercises];
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

        if (_exercises.Exists(x => x.RusPhrase == exercise.RusPhrase))
        {
            return Result.Failure(LessonErrors.ExerciseAlreadyExists);
        }

        _exercises.Add(exercise);

        return Result.Success();
    }

    public Result<bool> CompleteExercise(string answer, int exerciseId, int? userId)
    {
        Exercise? exercise = _exercises.Find(x => x.Id == exerciseId);

        if (exercise is null)
        {
            return Result.Failure<bool>(LessonErrors.ExerciseNotFound);
        }

        string correctAnswer = string.Join(' ', exercise.Words.Select(x => x.Text.Value));

        bool isCorrectAnswer = correctAnswer == answer;

        if (userId is null)
        {
            return Result.Success(isCorrectAnswer);
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

        return Result.Success(isCorrectAnswer);
    }
}
