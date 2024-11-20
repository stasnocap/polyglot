using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Levels;

public static class LevelErrors
{
    public static readonly Error NotFound =
        new("Level.NotFound",
            "Уровень не был найден.");
    
    public static readonly Error ExperienceNotMatchLevel =
        new("Level.ExperienceNotMatchLevel",
            "Очки опыта не соответствуют уровню.");
}
