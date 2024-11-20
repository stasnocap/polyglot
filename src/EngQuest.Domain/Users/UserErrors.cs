using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Users;

public static class UserErrors
{
    public static readonly Error NotFound = new(
        "User.Found",
        "Пользователь не найден");

    public static readonly Error Unauthorized = new(
        "User.Unauthorized",
        "Пользователь не авторизован");

    public static readonly Error Forbidden = new(
        "User.Forbidden",
        "У пользователя недостаточно прав");

    public static readonly Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "Неправильный логин или пароль");
}
