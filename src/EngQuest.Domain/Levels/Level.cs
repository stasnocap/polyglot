using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Levels;

public sealed class Level : Entity
{
    // ReSharper disable once InconsistentNaming
    private static readonly Dictionary<int, int> _requiredXp = [];
    
    public static IReadOnlyDictionary<int, int> RequiredXp
    {
        get
        {
            if (_requiredXp.Count != 0)
            {
                return _requiredXp;
            }

            Level level = One();
            
            int[] quests = Enumerable.Range(1, 30).ToArray();

            foreach (int quest in quests)
            {
                for (int i = 1; i <= 200; i++)
                {
                    if (!level.GainExperience(quest))
                    {
                        _requiredXp[quest + 1] = level.Experience;
                        continue;
                    }

                    break;
                }
            }

            return _requiredXp;
        }
    }

    public int UserId { get; private set; }
    public int Value { get; private set; }
    public int Experience { get; private set; }

    public static Level One() => new(1, 0);

    public static Result<Level> Create(int value, int experience)
    {
        if (experience > _requiredXp[value + 1])
        {
            return Result.Failure<Level>(LevelErrors.ExperienceNotMatchLevel);
        }
        
        return new Level(value, experience);
    }

    private Level(int value, int experience)
    {
        Value = value;
        Experience = experience;
    }

    private Level()
    {
    }

    public bool GainExperience(int questId)
    {
        if (Value > questId)
        {
            return false;
        }

        Experience += 10 + 2 * questId;

        if (Experience > 50 * Math.Pow(Value + 1, 2.2))
        {
            Value++;
            return true;
        }

        return false;
    }

    public void SetUserId(int userId)
    {
        UserId = userId;
    }
}
