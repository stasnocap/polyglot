using FluentAssertions;
using Polyglot.Domain.Lessons.Scores;

namespace Polyglot.Domain.UnitTests.Lessons.Scores;

public class RatingTests
{
    [Theory]
    [InlineData(50, 0, 5)]
    [InlineData(60, 0, 5)]
    [InlineData(60, 100, 0)]
    public void Increase_Should_CalculateCorrectRate(int correctNumber, int wrongNumber, float rate)
    {
        // Arrange
        var rating = new Rating(correctNumber - 1, wrongNumber, 0);
        
        // Act
        rating.Increase();

        // Assert
        rating.Rate.Should().Be(rate);
    }
    
    [Theory]
    [InlineData(50, 0, 5)]
    [InlineData(60, 0, 5)]
    [InlineData(60, 100, 0)]
    public void Decrease_Should_CalculateCorrectRate(int correctNumber, int wrongNumber, float rate)
    {
        // Arrange
        var rating = new Rating(correctNumber, wrongNumber - 1, 0);
        
        // Act
        rating.Decrease();

        // Assert
        rating.Rate.Should().Be(rate);
    }

    [Fact]
    public void Increase_Should_IncrementCorrectNumber()
    {
        // Arrange
        var rating = new Rating(RatingData.CorrectNumber, RatingData.WrongNumber, RatingData.Rate);
        
        // Act
        rating.Increase();
        
        // Assert
        rating.CorrectNumber.Should().Be(RatingData.CorrectNumber + 1);
    }

    [Fact]
    public void Decrease_Should_IncrementWrongNumber()
    {
        // Arrange
        var rating = new Rating(RatingData.CorrectNumber, RatingData.WrongNumber, RatingData.Rate);
        
        // Act
        rating.Decrease();
        
        // Assert
        rating.WrongNumber.Should().Be(RatingData.WrongNumber + 1);
    }
}
