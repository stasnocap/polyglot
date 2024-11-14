using Polyglot.Application.Abstractions.Messaging;

namespace Polyglot.Application.Users.LogInUser;

public sealed record LogInUserCommand(string Email, string Password)
    : ICommand<LogInResponse>;
