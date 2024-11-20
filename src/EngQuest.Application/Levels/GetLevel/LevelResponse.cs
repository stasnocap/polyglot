using EngQuest.Domain.Levels;

namespace EngQuest.Application.Levels.GetLevel;

public class LevelResponse
{
    private int? _levelRequiredXp;
    private int? _nextLevelRequiredXp;

    public required int Value { get; init; }
    public required int Experience { get; init; }

    public int LevelRequiredXp
    {
        get => _levelRequiredXp ??= Value > 1 ? Level.RequiredXp[Value] : 0;
        init => _levelRequiredXp = value;
    }

    public int NextLevelRequiredXp
    {
        get => _nextLevelRequiredXp ??= Value >= 1 ? Level.RequiredXp[Value + 1] : -1;
        init => _nextLevelRequiredXp = value;
    }
}
