using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;

namespace EngQuest.Infrastructure.Authorization;

[SuppressMessage("Major Code Smell", "S3993:Custom attributes should be marked with \"System.AttributeUsageAttribute\"")]
public sealed class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission);
