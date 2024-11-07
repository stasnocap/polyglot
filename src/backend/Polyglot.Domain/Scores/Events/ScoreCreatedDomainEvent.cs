using Polyglot.Domain.Abstractions;

namespace Polyglot.Domain.Scores.Events;

public sealed record ScoreCreatedDomainEvent(Guid ScoreId, Guid UserId, Guid LessonId) : IDomainEvent;
