using System.Security.Claims;
using EngQuest.Domain.Users;

namespace EngQuest.Infrastructure.Authentication;

public static class ClaimsPrincipalExtensions
{
    public static int? GetUserId(this ClaimsPrincipal? principal)
    {
        string? userId = principal?.FindFirstValue(ClaimTypes.NameIdentifier);

        return int.TryParse(userId, out int parsedUserId) ? parsedUserId : null;
    }

    public static string? GetIdentityId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(nameof(User.IdentityId));
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
