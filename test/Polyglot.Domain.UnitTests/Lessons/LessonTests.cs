using FluentAssertions;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Lessons;
using Polyglot.Domain.Lessons.Events;
using Polyglot.Domain.UnitTests.Infrastructure;

namespace Polyglot.Domain.UnitTests.Lessons;

public class LessonTests : BaseTest
{
    [Fact]
    public void Create_Should_SetPropertyValue()
    {
        // Act
        var lesson = Lesson.Create(LessonData.LessonNumber, LessonData.LessonName);
        
        // Assert
        lesson.Name.Should().Be(LessonData.LessonName);
        lesson.Number.Should().Be(LessonData.LessonNumber);
    }

    [Fact]
    public void Create_Should_RaiseLessonCreatedDomainEvent()
    {
        // Act
        var lesson = Lesson.Create(LessonData.LessonNumber, LessonData.LessonName);
        
        // Assert
        LessonCreatedDomainEvent lessonCreatedDomainEvent = AssertDomainEventWasPublished<LessonCreatedDomainEvent>(lesson);

        lessonCreatedDomainEvent.LessonId.Should().Be(lesson.Id);
    }

    [Fact]
    public void AddExercise_Should_AddExerciseToLesson_IfItHasNotAlreadyBeenAdded()
    {
        // Arrange
        var lesson = Lesson.Create(LessonData.LessonNumber, LessonData.LessonName);
        
        // Act

        Result result = lesson.AddExercise(LessonData.ExerciseId);
        
        // Assert

        result.IsSuccess.Should().BeTrue();
        lesson.ExerciseIds.Should().Contain(LessonData.ExerciseId);
    }

    [Fact]
    public void AddExercise_Should_ReturnError_IfExerciseHasAlreadyBeenAdded()
    {
        // Arrange
        var lesson = Lesson.Create(LessonData.LessonNumber, LessonData.LessonName);
        
        lesson.AddExercise(LessonData.ExerciseId);

        // Act

        Result result = lesson.AddExercise(LessonData.ExerciseId);
        
        // Assert

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(LessonErrors.ExerciseAlreadyAdded);
    }

    [Fact]
    public void AddScore_Should_AddScoreToLesson_IfItHasNotAlreadyBeenAdded()
    {
        // Arrange
        var lesson = Lesson.Create(LessonData.LessonNumber, LessonData.LessonName);
        
        // Act

        Result result = lesson.AddScore(LessonData.ScoreId);
        
        // Assert

        result.IsSuccess.Should().BeTrue();
        lesson.ScoreIds.Should().Contain(LessonData.ScoreId);
    }

    [Fact]
    public void AddScore_Should_ReturnError_IfScoreHasAlreadyBeenAdded()
    {
        // Arrange
        var lesson = Lesson.Create(LessonData.LessonNumber, LessonData.LessonName);
        
        lesson.AddScore(LessonData.ScoreId);

        // Act

        Result result = lesson.AddScore(LessonData.ScoreId);
        
        // Assert

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(LessonErrors.ScoreAlreadyAdded);
    }
}
