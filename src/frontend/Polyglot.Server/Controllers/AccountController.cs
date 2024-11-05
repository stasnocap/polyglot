using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Polyglot.Server.Controllers;

[ApiController]
[Route("")]
public class AccountController : ControllerBase
{
    [Authorize]
    [HttpGet("login")]
    public IActionResult Login(Uri? redirectUri)
    {
        redirectUri ??= new Uri("/");
        return Redirect(redirectUri.ToString());
    }

    [Authorize]
    [HttpGet("logout")]
    public async Task Logout(Uri? redirectUri)
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = redirectUri?.ToString() });
    }

    [HttpGet("ping-auth")]
    public IActionResult PingAuth()
    {
        string? email = User.FindFirstValue(ClaimTypes.Email);
        
        return Ok(new { Email = email });
    }
}
