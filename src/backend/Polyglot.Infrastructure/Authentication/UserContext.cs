using Microsoft.AspNetCore.Http;
using Polyglot.Application.Abstractions.Authentication;

namespace Polyglot.Infrastructure.Authentication;

internal sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public Guid? UserId =>
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
