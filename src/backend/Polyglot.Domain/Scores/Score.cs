using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Scores.Events;

namespace Polyglot.Domain.Scores;

public sealed class Score : Entity
{
    public Rating Rating { get; }
    public Guid UserId { get; }
    public Guid LessonId { get; }

    private Score(Guid id, Rating rating, Guid userId, Guid lessonId) : base(id)
    {
        Rating = rating;
        UserId = userId;
        LessonId = lessonId;
    }

    // ReSharper disable once UnusedMember.Local
    private Score()
    {
    }

    public static Score Create(Rating rating, Guid userId, Guid lessonId)
    {
        var score = new Score(Guid.NewGuid(), rating, userId, lessonId);

        score.RaiseDomainEvent(new ScoreCreatedDomainEvent(score.Id, userId, lessonId));

        return score;
    }
}
