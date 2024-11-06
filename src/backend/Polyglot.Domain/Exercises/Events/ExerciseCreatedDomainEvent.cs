using Polyglot.Domain.Abstractions;

namespace Polyglot.Domain.Exercises.Events;

public sealed record ExerciseCreatedDomainEvent(Guid ExerciseId) : IDomainEvent;
