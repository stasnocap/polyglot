using System.Data;
using Dapper;
using EngQuest.Application.Abstractions.Data;
using EngQuest.Application.Abstractions.Messaging;
using EngQuest.Domain.Abstractions;
using EngQuest.Domain.Levels;

namespace EngQuest.Application.Levels.GetLevel;

public class GetLevelQueryHandler(ISqlConnectionFactory _sqlConnectionFactory) : IQueryHandler<GetLevelQuery, LevelResponse>
{
    public async Task<Result<LevelResponse>> Handle(GetLevelQuery request, CancellationToken cancellationToken)
    {
        using IDbConnection dbConnection = _sqlConnectionFactory.CreateConnection();
        
        const string sql = """
                           SELECT level as Value, level_xp as Experience from levels
                           WHERE user_id = @UserId
                           LIMIT 1
                           """;

        LevelResponse? levelResponse = await dbConnection.QueryFirstOrDefaultAsync<LevelResponse>(sql, new { request.UserId });

        if (levelResponse is null)
        {
            return Result.Failure<LevelResponse>(LevelErrors.NotFound);
        }

        return levelResponse;
    }
}
