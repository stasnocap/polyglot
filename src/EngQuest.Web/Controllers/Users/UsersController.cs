using System.Security.Claims;
using Asp.Versioning;
using EngQuest.Application.Levels.GetLevel;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EngQuest.Application.Users.LogInUser;
using EngQuest.Application.Users.RegisterUser;
using EngQuest.Domain.Abstractions;
using EngQuest.Infrastructure.Authentication;
using EngQuest.Infrastructure.Authorization;

namespace EngQuest.Web.Controllers.Users;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/users")]
public class UsersController(ISender _sender) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("me")]
    [HasPermission(Permissions.UsersRead)]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLoggedInUser()
    {
        if (!User.Identity?.IsAuthenticated ?? true)
        {
            return NoContent();
        }

        int userId = User.GetUserId()!.Value;

        Result<LevelResponse> result = await _sender.Send(new GetLevelQuery(userId));

        if (result.IsFailure)
        {
            throw new Exception(result.Error.ToString());
        }

        LevelResponse level = result.Value;

        var userResponse = new UserResponse
        {
            FirstName = User.GetFirstName()!,
            LastName = User.GetLastName()!,
            Email = User.GetEmail()!,
            Level = level,
        };

        return Ok(userResponse);
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
            request.Password,
            request.Level,
            request.Experience);

        Result<LogInResponse> result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        ClaimsPrincipal principal = ClaimsPrincipalFactory.Create(result.Value);

        await HttpContext.SignInAsync(principal);
 
        return Ok(result.Value);
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LogIn(
        LogInUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = new LogInUserCommand(request.Email, request.Password);

        Result<LogInResponse> result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Unauthorized(result.Error);
        }

        ClaimsPrincipal principal = ClaimsPrincipalFactory.Create(result.Value);

        await HttpContext.SignInAsync(principal);

        return Ok();
    }
    
    [Authorize]
    [HttpGet("logout")]
    public async Task LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
