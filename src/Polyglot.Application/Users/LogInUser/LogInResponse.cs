namespace Polyglot.Application.Users.LogInUser;

public class LogInResponse
{
    public int UserId { get; init; }
    public string IdentityId { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public List<string> Roles { get; init; } = [];
}
