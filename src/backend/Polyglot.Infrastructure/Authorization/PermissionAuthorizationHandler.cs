using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Polyglot.Infrastructure.Authentication;

namespace Polyglot.Infrastructure.Authorization;

internal sealed class PermissionAuthorizationHandler(IServiceProvider serviceProvider) : AuthorizationHandler<PermissionRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        if (context.User.Identity is not { IsAuthenticated: true })
        {
            return;
        }

        using IServiceScope scope = serviceProvider.CreateScope();

        AuthorizationService authorizationService = scope.ServiceProvider.GetRequiredService<AuthorizationService>();

        string? identityId = context.User.GetIdentityId();

        HashSet<string> permissions = await authorizationService.GetPermissionsForUserAsync(identityId!);

        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }
}
