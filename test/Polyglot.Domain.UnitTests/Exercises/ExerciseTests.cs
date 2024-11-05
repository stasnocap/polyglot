using FluentAssertions;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Exercises;
using Polyglot.Domain.Exercises.Events;
using Polyglot.Domain.UnitTests.Infrastructure;

namespace Polyglot.Domain.UnitTests.Exercises;

public class ExerciseTests : BaseTest
{
    [Fact]
    public void Create_Should_SetPropertyValue()
    {
        // Act
        var exercise = Exercise.Create(ExerciseData.RusPhrase, ExerciseData.Words);
        
        // Assert
        exercise.RusPhrase.Should().Be(ExerciseData.RusPhrase);
        foreach (Word word in ExerciseData.Words)
        {
            exercise.Words.Should().Contain(word);
        }
    }

    [Fact]
    public void Create_Should_RaiseExerciseCreatedDomainEvent()
    {
        // Act
        var exercise = Exercise.Create(ExerciseData.RusPhrase, ExerciseData.Words);
        
        // Assert
        ExerciseCreatedDomainEvent exerciseCreatedDomainEvent = AssertDomainEventWasPublished<ExerciseCreatedDomainEvent>(exercise);

        exerciseCreatedDomainEvent.ExerciseId.Should().Be(exercise.Id);
    }

    [Fact]
    public void AddLesson_Should_AddLessonToExercise_IfItHasNotAlreadyBeenAdded()
    {
        // Arrange
        var exercise = Exercise.Create(ExerciseData.RusPhrase, ExerciseData.Words);
        
        // Act

        Result result = exercise.AddLesson(ExerciseData.LessonId);
        
        // Assert

        result.IsSuccess.Should().BeTrue();
        exercise.LessonIds.Should().Contain(ExerciseData.LessonId);
    }

    [Fact]
    public void AddLesson_Should_ReturnError_IfLessonHasAlreadyBeenAdded()
    {
        // Arrange
        var exercise = Exercise.Create(ExerciseData.RusPhrase, ExerciseData.Words);
        
        exercise.AddLesson(ExerciseData.LessonId);

        // Act

        Result result = exercise.AddLesson(ExerciseData.LessonId);
        
        // Assert

        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(ExerciseErrors.LessonAlreadyAdded);
    }
}
