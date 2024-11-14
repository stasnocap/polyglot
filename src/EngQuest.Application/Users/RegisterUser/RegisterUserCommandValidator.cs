using FluentValidation;

namespace EngQuest.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().WithName("Имя");

        RuleFor(c => c.LastName).NotEmpty().WithName("Фамилия");

        RuleFor(c => c.Email).EmailAddress();

        RuleFor(c => c.Password).NotEmpty().MinimumLength(5).WithName("Пароль");
    }
}
