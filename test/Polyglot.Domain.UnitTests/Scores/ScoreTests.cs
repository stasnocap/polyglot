using FluentAssertions;
using Polyglot.Domain.Scores;
using Polyglot.Domain.Scores.Events;
using Polyglot.Domain.UnitTests.Infrastructure;

namespace Polyglot.Domain.UnitTests.Scores;

public class ScoreTests : BaseTest
{
    [Fact]
    public void Create_Should_SetPropertyValue()
    {
        // Act
        var score = Score.Create(ScoreData.Rating, ScoreData.UserId, ScoreData.LessonId);
        
        // Assert
        score.Rating.Should().Be(ScoreData.Rating);
        score.UserId.Should().Be(ScoreData.UserId);
        score.LessonId.Should().Be(ScoreData.LessonId);
    }

    [Fact]
    public void Create_Should_RaiseScoreCreatedDomainEvent()
    {
        // Act
        var score = Score.Create(ScoreData.Rating, ScoreData.UserId, ScoreData.LessonId);
        
        // Assert
        ScoreCreatedDomainEvent scoreCreatedDomainEvent = AssertDomainEventWasPublished<ScoreCreatedDomainEvent>(score);

        scoreCreatedDomainEvent.ScoreId.Should().Be(score.Id);
    }
}
