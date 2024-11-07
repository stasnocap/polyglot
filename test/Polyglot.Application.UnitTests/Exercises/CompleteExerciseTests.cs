using FluentAssertions;
using NSubstitute;
using Polyglot.Application.Abstractions.Authentication;
using Polyglot.Application.Exercises.CompleteExercise;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Exercises;
using Polyglot.Domain.Scores;

namespace Polyglot.Application.UnitTests.Exercises;

public class CompleteExerciseTests
{
    private static readonly Guid UserId = Guid.NewGuid();
    private static readonly CompleteExerciseCommand Command = new(Guid.NewGuid(), Guid.NewGuid(), "Answer");

    private readonly CompleteExerciseCommandHandler _handler;
    private readonly IExerciseRepository _exerciseRepositoryMock;
    private readonly IScoreRepository _scoreRepositoryMock;
    private readonly IUserContext _userContextMock;
    private readonly IUnitOfWork _unitOfWorkMock;

    public CompleteExerciseTests()
    {
        _exerciseRepositoryMock = Substitute.For<IExerciseRepository>();
        _scoreRepositoryMock = Substitute.For<IScoreRepository>();
        _userContextMock = Substitute.For<IUserContext>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();

        _handler = new CompleteExerciseCommandHandler
        (
            _exerciseRepositoryMock,
            _scoreRepositoryMock,
            _userContextMock,
            _unitOfWorkMock
        );
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_IfExerciseDoesNotExist()
    {
        // Arrange
        _exerciseRepositoryMock
            .GetAnswerAsync(Command.ExerciseId, Arg.Any<CancellationToken>())
            .Returns(null as string);

        // Act
        Result<CompleteExerciseResponse> result = await _handler.Handle(Command, CancellationToken.None);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ExerciseErrors.NotFound);
    }

    [Theory]
    [InlineData("5ead44f1-8d66-4a2f-8f95-63479601b41e")]
    [InlineData(null)]
    public async Task Handle_Should_ReturnSuccess_IfAnswerIsCorrect(string? userIdStr)
    {
        Guid? userId = userIdStr is null
            ? null
            : Guid.Parse(userIdStr);
        
        // Arrange
        _exerciseRepositoryMock
            .GetAnswerAsync(Command.ExerciseId, Arg.Any<CancellationToken>())
            .Returns(Command.Answer);

        _userContextMock
            .UserId
            .Returns(userId);

        // Act
        Result<CompleteExerciseResponse> result = await _handler.Handle(Command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Success.Should().BeTrue();
    }

    [Theory]
    [InlineData("5ead44f1-8d66-4a2f-8f95-63479601b41e")]
    [InlineData(null)]
    public async Task Handle_Should_ReturnFailure_IfAnswerIsNotCorrect(string? userIdStr)
    {
        Guid? userId = userIdStr is null
            ? null
            : Guid.Parse(userIdStr);
        
        // Arrange
        _exerciseRepositoryMock
            .GetAnswerAsync(Command.ExerciseId, Arg.Any<CancellationToken>())
            .Returns(Command.Answer + " 123");

        _userContextMock
            .UserId
            .Returns(userId);

        // Act
        Result<CompleteExerciseResponse> result = await _handler.Handle(Command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Success.Should().BeFalse();
    }

    [Theory]
    [InlineData("5ead44f1-8d66-4a2f-8f95-63479601b41e", true)]
    [InlineData(null, true)]
    [InlineData("5ead44f1-8d66-4a2f-8f95-63479601b41e", false)]
    [InlineData(null, false)]
    public async Task Handle_Should_ReturnCorrectAnswerAndExerciseId(string? userIdStr, bool isCorrectAnswer)
    {
        Guid? userId = userIdStr is null
            ? null
            : Guid.Parse(userIdStr);
        
        // Arrange
        string correctAnswer = isCorrectAnswer ? Command.Answer : Command.Answer + " 123";
        
        _exerciseRepositoryMock
            .GetAnswerAsync(Command.ExerciseId, Arg.Any<CancellationToken>())
            .Returns(correctAnswer);

        _userContextMock
            .UserId
            .Returns(userId);

        // Act
        Result<CompleteExerciseResponse> result = await _handler.Handle(Command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.CorrectAnswer.Should().Be(correctAnswer);
        result.Value.ExerciseId.Should().Be(Command.ExerciseId);
    }

    [Fact]
    public async Task Handle_Should_CreateScore_IfNotExists()
    {
        // Arrange
        _userContextMock
            .UserId
            .Returns(UserId);
        
        _exerciseRepositoryMock
            .GetAnswerAsync(Command.ExerciseId, Arg.Any<CancellationToken>())
            .Returns(Command.Answer);

        Score? score = null;
        _scoreRepositoryMock
            .GetAsync(Command.LessonId, UserId, Arg.Any<CancellationToken>())
            .Returns(score);

        // Act
        Result<CompleteExerciseResponse> result = await _handler.Handle(Command, CancellationToken.None);
    
        // Assert
        result.IsSuccess.Should().BeTrue();
        _scoreRepositoryMock.Received(1).Add(Arg.Any<Score>());
        await _unitOfWorkMock.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_Should_IncreaseScore_IfCorrect()
    {
        // Arrange
        _userContextMock
            .UserId
            .Returns(UserId);
        
        _exerciseRepositoryMock
            .GetAnswerAsync(Command.ExerciseId, Arg.Any<CancellationToken>())
            .Returns(Command.Answer);

        var score = Score.Create(Rating.Init(), UserId, Command.LessonId);
        _scoreRepositoryMock
            .GetAsync(Command.LessonId, UserId, Arg.Any<CancellationToken>())
            .Returns(score);

        // Act
        Result<CompleteExerciseResponse> result = await _handler.Handle(Command, CancellationToken.None);
    
        // Assert
        result.IsSuccess.Should().BeTrue();
        score.Rating.CorrectNumber.Should().Be(1);
    }

    [Fact]
    public async Task Handle_Should_DecreaseScore_IfIncorrect()
    {
        // Arrange
        _userContextMock
            .UserId
            .Returns(UserId);
        
        _exerciseRepositoryMock
            .GetAnswerAsync(Command.ExerciseId, Arg.Any<CancellationToken>())
            .Returns(Command.Answer + "123");

        var score = Score.Create(Rating.Init(), UserId, Command.LessonId);
        _scoreRepositoryMock
            .GetAsync(Command.LessonId, UserId, Arg.Any<CancellationToken>())
            .Returns(score);

        // Act
        Result<CompleteExerciseResponse> result = await _handler.Handle(Command, CancellationToken.None);
    
        // Assert
        result.IsSuccess.Should().BeTrue();
        score.Rating.WrongNumber.Should().Be(1);
    }
}
