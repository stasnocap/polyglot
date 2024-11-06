using FluentAssertions;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.ModalVerbs;

namespace Polyglot.Domain.UnitTests.Vocabulary.ModalVerbs;

public class FullNegativeFormTests
{
    [Fact]
    public void Is_Should_ReturnTrue_IfModalVerbEndsWithNot()
    {
        // Arrange
        var fullNegativeForm = new Text("do not");
        
        // Act
        bool result = FullNegativeForm.Is(fullNegativeForm);

        // Assert
        result.Should().BeTrue();
    }
}
