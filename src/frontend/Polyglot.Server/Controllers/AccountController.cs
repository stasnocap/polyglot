using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Polyglot.Server.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    [Authorize]
    [HttpGet("login")]
    public IActionResult Login(string? redirectUri)
    {
        redirectUri ??= "/";
        return Redirect(redirectUri);
    }

    [Authorize]
    [HttpGet("logout")]
    public async Task Logout(string? redirectUri)
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = redirectUri });
    }

    [HttpGet("ping-auth")]
    public IActionResult PingAuth()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        
        return Ok(new { Email = email });
    }
}