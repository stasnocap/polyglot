using Polyglot.Domain.Abstractions;

namespace Polyglot.Domain.Users;

public static class UserErrors
{
    public static readonly Error NotFound = new(
        "User.Found",
        "Пользователь не найден");

    public static readonly Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "Неправильный логин или пароль");

    public static readonly Error ScoreAlreadyAdded = new(
        "User.ScoreAlreadyAdded",
        "The score is already added");
}
