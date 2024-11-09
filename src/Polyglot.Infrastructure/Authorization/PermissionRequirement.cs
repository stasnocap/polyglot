using Microsoft.AspNetCore.Authorization;

namespace Polyglot.Infrastructure.Authorization;

internal sealed class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}
