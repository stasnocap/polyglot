using EngQuest.Domain.Abstractions;

namespace EngQuest.Application.Exceptions;

public sealed class ForbiddenException(Error error) : Exception
{
    public Error Error { get; } = error;
}
