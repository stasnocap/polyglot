using Microsoft.AspNetCore.Http;
using EngQuest.Application.Abstractions.Authentication;

namespace EngQuest.Infrastructure.Authentication;

internal sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public int? UserId =>
        httpContextAccessor
            .HttpContext?
            .User
            .GetUserId();

    public string? IdentityId =>
        httpContextAccessor
            .HttpContext?
            .User
            .GetIdentityId();
}
