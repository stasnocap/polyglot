using System.Security.Claims;
using Polyglot.Domain.Users;

namespace Polyglot.Infrastructure.Authentication;

public static class ClaimsPrincipalExtensions
{
    public static int? GetUserId(this ClaimsPrincipal? principal)
    {
        string? userId = principal?.FindFirstValue(nameof(User.IdentityId));

        return int.TryParse(userId, out int parsedUserId) ? parsedUserId : null;
    }

    public static string? GetIdentityId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public static string? GetFirstName(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(nameof(User.FirstName));
    }

    public static string? GetLastName(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(nameof(User.LastName));
    }

    public static string? GetEmail(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(nameof(User.Email));
    }
}
