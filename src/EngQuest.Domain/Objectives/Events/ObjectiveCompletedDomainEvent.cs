using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Objectives.Events;

public record ObjectiveCompletedDomainEvent(int QuestId, int UserId) : IDomainEvent;
