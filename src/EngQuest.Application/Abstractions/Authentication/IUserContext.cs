namespace EngQuest.Application.Abstractions.Authentication;

public interface IUserContext
{
    int? UserId { get; }

    string? IdentityId { get; }
}
