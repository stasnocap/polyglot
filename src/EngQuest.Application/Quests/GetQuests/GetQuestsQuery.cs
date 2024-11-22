using EngQuest.Application.Abstractions.Caching;

namespace EngQuest.Application.Quests.GetQuests;

public record GetQuestsQuery : ICachedQuery<IReadOnlyList<QuestResponse>>
{
    public string CacheKey => "quests";
    public TimeSpan? Expiration => null;
}
