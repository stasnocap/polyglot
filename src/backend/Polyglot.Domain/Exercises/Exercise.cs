using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Exercises.Events;

namespace Polyglot.Domain.Exercises;

public sealed class Exercise : Entity
{
    private readonly List<Word> _words = [];
    private readonly List<Guid> _lessonIds = [];
    
    public RusPhrase RusPhrase { get; }
    
    public IReadOnlyCollection<Word> Words => [.._words];
    public IReadOnlyCollection<Guid> LessonIds => [.._lessonIds];
    
    private Exercise(Guid id, RusPhrase rusPhrase) : base(id)
    {
        RusPhrase = rusPhrase;
    }
    
    // ReSharper disable once UnusedMember.Local
    private Exercise()
    {
    }

    public static Exercise Create(RusPhrase rusPhrase, IEnumerable<Word> words)
    {
        return Create(Guid.NewGuid(), rusPhrase, words);
    }

    public static Exercise Create(Guid exerciseId, RusPhrase rusPhrase, IEnumerable<Word> words)
    {
        var exercise = new Exercise(exerciseId, rusPhrase);
        
        exercise.RaiseDomainEvent(new ExerciseCreatedDomainEvent(exerciseId));
        
        exercise._words.AddRange(words);

        return exercise;
    }

    public Result AddLesson(Guid lessonId)
    {
        if (_lessonIds.Contains(lessonId))
        {
            return Result.Failure(ExerciseErrors.LessonAlreadyAdded);
        }
        
        _lessonIds.Add(lessonId);

        return Result.Success();
    }
}
