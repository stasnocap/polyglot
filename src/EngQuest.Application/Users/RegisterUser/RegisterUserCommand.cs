using EngQuest.Application.Abstractions.Messaging;
using EngQuest.Application.Users.LogInUser;

namespace EngQuest.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
        string Email,
        string FirstName,
        string LastName,
        string Password) : ICommand<LogInResponse>;
