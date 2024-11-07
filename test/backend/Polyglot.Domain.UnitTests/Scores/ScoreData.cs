using Polyglot.Domain.Scores;

namespace Polyglot.Domain.UnitTests.Scores;

internal static class ScoreData
{
    public static readonly Rating Rating = new Rating(RatingData.CorrectNumber, RatingData.WrongNumber, RatingData.Rate);
    public static readonly Guid UserId = Guid.Parse("882db0d7-e2f8-4c1a-b6a2-8db96798a548");
    public static readonly Guid LessonId = Guid.Parse("e95c9c43-0b3d-44b7-be6a-2774843e6508");
}
