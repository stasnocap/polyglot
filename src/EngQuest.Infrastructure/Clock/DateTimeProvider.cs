using EngQuest.Application.Abstractions.Clock;

namespace EngQuest.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
