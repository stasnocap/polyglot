using System.Text.Json.Serialization;

namespace EngQuest.Web.Controllers.Users;

public sealed record RegisterUserRequest(
    string Email,
    string FirstName,
    string LastName,
    string Password,
    [property: JsonRequired] int Level,
    [property: JsonRequired] int Experience
);
