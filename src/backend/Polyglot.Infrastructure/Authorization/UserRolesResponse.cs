using Polyglot.Domain.Users;

namespace Polyglot.Infrastructure.Authorization;

internal sealed class UserRolesResponse
{
    public int UserId { get; init; }

    public List<Role> Roles { get; init; } = [];
}
