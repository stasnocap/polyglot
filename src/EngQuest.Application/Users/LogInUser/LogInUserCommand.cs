using EngQuest.Application.Abstractions.Messaging;

namespace EngQuest.Application.Users.LogInUser;

public sealed record LogInUserCommand(string Email, string Password)
    : ICommand<LogInResponse>;
