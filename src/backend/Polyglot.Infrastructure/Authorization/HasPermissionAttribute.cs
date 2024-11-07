using Microsoft.AspNetCore.Authorization;

namespace Polyglot.Infrastructure.Authorization;

public sealed class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission);
