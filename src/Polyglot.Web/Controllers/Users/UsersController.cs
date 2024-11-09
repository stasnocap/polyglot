using System.Security.Claims;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polyglot.Application.Users.GetLoggedInUser;
using Polyglot.Application.Users.RegisterUser;
using Polyglot.Domain.Abstractions;
using Polyglot.Infrastructure.Authorization;

namespace Polyglot.Web.Controllers.Users;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/users")]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("me")]
    [HasPermission(Permissions.UsersRead)]
    public async Task<IActionResult> GetLoggedInUser(CancellationToken cancellationToken)
    {
        var query = new GetLoggedInUserQuery();

        Result<UserResponse> result = await _sender.Send(query, cancellationToken);

        return Ok(result.Value);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = new RegisterUserCommand(
            request.Email,
            request.FirstName,
            request.LastName,
            request.Password);

        Result<int> result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [Authorize]
    [HttpGet("login")]
    public IActionResult LogIn(Uri? redirectUri)
    {
        return Redirect(redirectUri?.ToString()?? "/");
    }
    
    [Authorize]
    [HttpGet("logout")]
    public async Task LogOut(Uri? redirectUri)
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = redirectUri?.ToString() });
    }
    
    [AllowAnonymous]
    [HttpGet("ping-auth")]
    [ProducesResponseType(typeof(PingAuthResponse), StatusCodes.Status200OK)]
    public IActionResult PingAuth()
    {
        string? email = User.FindFirstValue(ClaimTypes.Email);
        
        return Ok(new PingAuthResponse(email));
    }
}
