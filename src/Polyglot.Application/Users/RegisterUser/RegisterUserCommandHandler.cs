using Polyglot.Application.Abstractions.Authentication;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Application.Users.LogInUser;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Users;

namespace Polyglot.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler(
    IAuthenticationService authenticationService,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<RegisterUserCommand, LogInResponse>
{
    public async Task<Result<LogInResponse>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = User.Create(
            new FirstName(request.FirstName),
            new LastName(request.LastName),
            new Email(request.Email));

        string identityId = await authenticationService.RegisterAsync(
            user,
            request.Password,
            cancellationToken);

        user.SetIdentityId(identityId);

        userRepository.Add(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new LogInResponse()
        {
            Email = user.Email.Value,
            FirstName = user.FirstName.Value,
            LastName = user.LastName.Value,
            Roles = user.Roles.Select(x => x.Name).ToList(),
            IdentityId = user.IdentityId,
            UserId = user.Id,
        };
    }
}
