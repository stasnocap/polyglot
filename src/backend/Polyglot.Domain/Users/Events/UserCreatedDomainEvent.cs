using Polyglot.Domain.Abstractions;

namespace Polyglot.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
