using Polyglot.Application.Abstractions.Clock;

namespace Polyglot.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
