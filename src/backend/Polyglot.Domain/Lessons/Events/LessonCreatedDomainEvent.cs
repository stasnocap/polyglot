using Polyglot.Domain.Abstractions;

namespace Polyglot.Domain.Lessons.Events;

public sealed record LessonCreatedDomainEvent(Guid LessonId) : IDomainEvent;
