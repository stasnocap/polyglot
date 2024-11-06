namespace Polyglot.Domain.Scores;

public sealed record Rating(int CorrectNumber, int WrongNumber, float Rate)
{
    public int CorrectNumber { get; private set; } = CorrectNumber;
    public int WrongNumber { get; private set; } = WrongNumber;
    public float Rate { get; private set; } = Rate;
    
    private const float SuccessMultiplier = 0.1f;
    private const float WrongMultiplier = 0.15f;
    private const float MaxRate = 5f;
    private const float MinRate = 0;

    public static Rating Init() => new(0, 0, 0);

    public void Increase()
    {
        CorrectNumber++;
        CalculateRate();
    }

    public void Decrease()
    {
        WrongNumber++;
        CalculateRate();
    }

    private void CalculateRate()
    {
        float rate = CorrectNumber * SuccessMultiplier - WrongNumber * WrongMultiplier;

        Rate = rate switch
        {
            > MaxRate => MaxRate,
            < MinRate => MinRate,
            _ => rate
        };
    }
}
