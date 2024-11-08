using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Polyglot.Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
{
    public static int? GetUserId(this ClaimsPrincipal? principal)
    {
        string? userId = principal?.FindFirstValue(JwtRegisteredClaimNames.Sub);

        return int.TryParse(userId, out int parsedUserId) ? parsedUserId : null;
    }

    public static string? GetIdentityId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
