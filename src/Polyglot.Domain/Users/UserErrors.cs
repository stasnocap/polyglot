using Polyglot.Domain.Abstractions;

namespace Polyglot.Domain.Users;

public static class UserErrors
{
    public static readonly Error NotFound = new(
        "User.Found",
        "The user with the specified identifier was not found");

    public static readonly Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "The provided credentials were invalid");

    public static readonly Error ScoreAlreadyAdded = new(
        "User.ScoreAlreadyAdded",
        "The score is already added");
}
