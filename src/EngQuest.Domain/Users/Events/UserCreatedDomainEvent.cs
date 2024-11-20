using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Users.Events;

public record UserCreatedDomainEvent(int UserId) : IDomainEvent;
