using EngQuest.Application.Abstractions.Caching;

namespace EngQuest.Application.Levels.GetLevel;

public record GetLevelQuery(int UserId) : ICachedQuery<LevelResponse>
{
    public string CacheKey => $"level-{UserId}";
    public TimeSpan? Expiration => TimeSpan.FromHours(12);
};
