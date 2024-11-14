using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Application.Users.LogInUser;

namespace Polyglot.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
        string Email,
        string FirstName,
        string LastName,
        string Password) : ICommand<LogInResponse>;
