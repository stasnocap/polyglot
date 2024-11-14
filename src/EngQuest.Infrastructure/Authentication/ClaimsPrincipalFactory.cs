using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using EngQuest.Application.Users.LogInUser;
using EngQuest.Domain.Users;

namespace EngQuest.Infrastructure.Authentication;

public static class ClaimsPrincipalFactory
{
    public static ClaimsPrincipal Create(LogInResponse logInResponse)
    {
        List<Claim> claims =
        [
            new(ClaimTypes.NameIdentifier, logInResponse.UserId.ToString(CultureInfo.InvariantCulture)),
            new(nameof(User.IdentityId), logInResponse.IdentityId),
            new(nameof(User.FirstName), logInResponse.FirstName),
            new(nameof(User.LastName), logInResponse.LastName),
            new(nameof(User.Email), logInResponse.Email),
        ];
        
        foreach (string role in logInResponse.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        
        var principal = new ClaimsPrincipal(identity);
        
        return principal;
    }
}
