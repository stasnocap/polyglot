namespace EngQuest.Domain.Users;

public record Level(int Value)
{
    public static Level One() => new(1);
    
    public int Value { get; private set; } = Value;
    public int Experience { get; private set; }

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
};
