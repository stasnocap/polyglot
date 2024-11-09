using System.Data;
using Dapper;
using Polyglot.Application.Abstractions.Authentication;
using Polyglot.Application.Abstractions.Data;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;

namespace Polyglot.Application.Users.GetLoggedInUser;

internal sealed class GetLoggedInUserQueryHandler(
    ISqlConnectionFactory sqlConnectionFactory,
    IUserContext userContext) : IQueryHandler<GetLoggedInUserQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(
        GetLoggedInUserQuery request,
        CancellationToken cancellationToken)
    {
        using IDbConnection connection = sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id AS Id,
                first_name AS FirstName,
                last_name AS LastName,
                email AS Email
            FROM users
            WHERE identity_id = @IdentityId
            """;

        UserResponse user = await connection.QuerySingleAsync<UserResponse>(
            sql,
            new
            {
                userContext.IdentityId
            });

        return user;
    }
}
