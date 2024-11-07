using Polyglot.Application.Abstractions.Messaging;

namespace Polyglot.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
        string Email,
        string FirstName,
        string LastName,
        string Password) : ICommand<Guid>;
