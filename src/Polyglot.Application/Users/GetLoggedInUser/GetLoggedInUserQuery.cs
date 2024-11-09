using Polyglot.Application.Abstractions.Messaging;

namespace Polyglot.Application.Users.GetLoggedInUser;

public sealed record GetLoggedInUserQuery : IQuery<UserResponse>;
