using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Lessons.Events;

namespace Polyglot.Domain.Lessons;

public sealed class Lesson : Entity
{
    private readonly List<Guid> _exerciseIds = [];
    private readonly List<Guid> _scoreIds = [];
    
    public LessonNumber Number { get; }
    public LessonName Name { get; }
    
    public IReadOnlyCollection<Guid> ExerciseIds => [.._exerciseIds];
    public IReadOnlyCollection<Guid> ScoreIds => [.._scoreIds];

    private Lesson(Guid id, LessonNumber number, LessonName name) : base(id)
    {
        Number = number;
        Name = name;
    }

    // ReSharper disable once UnusedMember.Local
    private Lesson()
    {
    }

    public static Lesson Create(LessonNumber number, LessonName name)
    {
        return Create(Guid.NewGuid(), number, name);
    }

    public static Lesson Create(Guid lessonId, LessonNumber number, LessonName name)
    {
        var lesson = new Lesson(lessonId, number, name);
        
        lesson.RaiseDomainEvent(new LessonCreatedDomainEvent(lessonId));
        
        return lesson;
    }

    public Result AddExercise(Guid exerciseId)
    {
        if (_exerciseIds.Contains(exerciseId))
        {
            return Result.Failure(LessonErrors.ExerciseAlreadyAdded);
        }
        
        _exerciseIds.Add(exerciseId);

        return Result.Success();
    }

    public Result AddScore(Guid scoreId)
    {
        if (_scoreIds.Contains(scoreId))
        {
            return Result.Failure(LessonErrors.ScoreAlreadyAdded);
        }
        
        _scoreIds.Add(scoreId);
        
        return Result.Success();
    }
}
