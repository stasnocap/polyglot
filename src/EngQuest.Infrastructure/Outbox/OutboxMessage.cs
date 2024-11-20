namespace EngQuest.Infrastructure.Outbox;

public sealed class OutboxMessage(DateTime occurredOnUtc, string type, string content)
{
    public int Id { get; init; }

    public DateTime OccurredOnUtc { get; init; } = occurredOnUtc;

    public string Type { get; init; } = type;

    public string Content { get; init; } = content;

    public DateTime? ProcessedOnUtc { get; init; }

    public string? Error { get; init; }
}
