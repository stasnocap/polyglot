using EngQuest.Application.Levels.GetLevel;

namespace EngQuest.Web.Controllers.Users;

public class UserResponse
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required LevelResponse Level { get; init; }
}
