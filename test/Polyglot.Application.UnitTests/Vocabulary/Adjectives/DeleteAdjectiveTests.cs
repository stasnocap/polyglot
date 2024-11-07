using FluentAssertions;
using NSubstitute;
using Polyglot.Application.Vocabulary.Adjectives.DeleteAdjective;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.Adjectives;

namespace Polyglot.Application.UnitTests.Vocabulary.Adjectives;

public class DeleteAdjectiveTests
{
    private readonly DeleteAdjectiveCommand _command = new(Guid.NewGuid());

    private readonly IUnitOfWork _unitOfWorkMock;
    private readonly IAdjectiveRepository _adjectiveRepositoryMock;

    private readonly DeleteAdjectiveCommandHandler _handler;

    public DeleteAdjectiveTests()
    {
        _adjectiveRepositoryMock = Substitute.For<IAdjectiveRepository>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();

        _handler = new DeleteAdjectiveCommandHandler(_adjectiveRepositoryMock, _unitOfWorkMock);
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
    public async Task Handle_Should_DeleteAdjective()
    {
        // Act
        var adjective = new Adjective(_command.Id, new Text("bad"));
        
        _adjectiveRepositoryMock
            .GetByIdAsync(_command.Id, Arg.Any<CancellationToken>())
            .Returns(adjective);

        // Arrange
        Result result = await _handler.Handle(_command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _adjectiveRepositoryMock.Received(1).Delete(adjective);
        await _unitOfWorkMock.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }
}
