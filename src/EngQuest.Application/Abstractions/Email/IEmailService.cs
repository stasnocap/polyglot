namespace EngQuest.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(EngQuest.Domain.Users.Email recipient, string subject, string body);
}
