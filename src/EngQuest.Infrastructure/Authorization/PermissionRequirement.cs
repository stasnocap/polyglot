using Microsoft.AspNetCore.Authorization;

namespace EngQuest.Infrastructure.Authorization;

internal sealed class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}
