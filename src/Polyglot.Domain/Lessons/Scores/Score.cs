namespace Polyglot.Domain.Lessons.Scores;

public sealed class Score
{
    public int Id { get; init; }
    public Rating Rating { get; }
    public int UserId { get; }

    internal Score(Rating rating, int userId)
    {
        Rating = rating;
        UserId = userId;
    }

    // ReSharper disable once UnusedMember.Local
    private Score()
    {
    }
}
