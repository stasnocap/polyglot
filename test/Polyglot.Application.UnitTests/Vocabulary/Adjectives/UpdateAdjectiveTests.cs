using FluentAssertions;
using NSubstitute;
using Polyglot.Application.Vocabulary.Adjectives.UpdateAdjective;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.Adjectives;

namespace Polyglot.Application.UnitTests.Vocabulary.Adjectives;

public class UpdateAdjectiveTests
{
    private readonly UpdateAdjectiveCommand _command = new(Guid.NewGuid(), "big");

    private readonly IUnitOfWork _unitOfWorkMock;
    private readonly IAdjectiveRepository _adjectiveRepositoryMock;

    private readonly UpdateAdjectiveCommandHandler _handler;

    public UpdateAdjectiveTests()
    {
        _adjectiveRepositoryMock = Substitute.For<IAdjectiveRepository>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();

        _handler = new UpdateAdjectiveCommandHandler(_adjectiveRepositoryMock, _unitOfWorkMock);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_IfAdjectiveIsNotFound()
    {
        // Act
        _adjectiveRepositoryMock
            .GetByIdAsync(_command.Id, Arg.Any<CancellationToken>())
            .Returns(null as Adjective);

        // Arrange
        Result result = await _handler.Handle(_command, CancellationToken.None);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(AdjectiveErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_IfAdjectiveAlreadyExists()
    {
        // Act
        var adjective = new Adjective(_command.Id, new Text("bad"));

        _adjectiveRepositoryMock
            .GetByIdAsync(_command.Id, Arg.Any<CancellationToken>())
            .Returns(adjective);
        
        _adjectiveRepositoryMock
            .ExistsAsync(Arg.Is<Text>(x => x.Value == _command.Text), Arg.Any<CancellationToken>())
            .Returns(true);

        // Arrange
        Result result = await _handler.Handle(_command, CancellationToken.None);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(AdjectiveErrors.AlreadyExists);
    }

    [Fact]
    public async Task Handle_Should_UpdateAdjectiveText()
    {
        // Act
        var adjective = new Adjective(_command.Id, new Text("bad"));
        
        _adjectiveRepositoryMock
            .GetByIdAsync(_command.Id, Arg.Any<CancellationToken>())
            .Returns(adjective);
        
        _adjectiveRepositoryMock
            .ExistsAsync(Arg.Is<Text>(x => x.Value == _command.Text), Arg.Any<CancellationToken>())
            .Returns(false);

        // Arrange
        Result result = await _handler.Handle(_command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        adjective.Text.Value.Should().Be(_command.Text);
        await _unitOfWorkMock.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }

}
