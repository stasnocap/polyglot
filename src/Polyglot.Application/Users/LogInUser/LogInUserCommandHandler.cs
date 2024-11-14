using System.Data;
using Dapper;
using Polyglot.Application.Abstractions.Authentication;
using Polyglot.Application.Abstractions.Data;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Users;

namespace Polyglot.Application.Users.LogInUser;

internal sealed class LogInUserCommandHandler(IJwtService _jwtService, ISqlConnectionFactory _sqlConnectionFactory) : ICommandHandler<LogInUserCommand, LogInResponse>
{
    public async Task<Result<LogInResponse>> Handle(
        LogInUserCommand request,
        CancellationToken cancellationToken)
    {
        Result<string> result = await _jwtService.GetAccessTokenAsync(
            request.Email,
            request.Password,
            cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<LogInResponse>(UserErrors.InvalidCredentials);
        }

        using IDbConnection dbConnection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
                           SELECT 
                                u.id AS UserId, 
                                u.first_name AS FirstName, 
                                u.last_name AS LastName, 
                                u.email AS Email, 
                                u.identity_id AS IdentityId,
                                r.name AS Role
                           FROM users AS u
                           JOIN role_user AS ru ON ru.users_id  = u.id
                           JOIN roles AS r ON ru.roles_id = r.id
                           WHERE u.email = @Email
                           """;
        
        var roles = new List<string>();
        
        IEnumerable<LogInResponse> users = await dbConnection.QueryAsync<LogInResponse, string, LogInResponse>(sql, (user, role) =>
        {
            roles.Add(role);
            return user;
        }, request, splitOn: "Role");

        LogInResponse logIn = users.Single();
        
        logIn.Roles.AddRange(roles);

        return logIn;
    }
}
