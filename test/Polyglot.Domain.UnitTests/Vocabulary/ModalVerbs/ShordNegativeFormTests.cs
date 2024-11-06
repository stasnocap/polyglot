using FluentAssertions;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.ModalVerbs;

namespace Polyglot.Domain.UnitTests.Vocabulary.ModalVerbs;

public class ShortNegativeFormTests
{
    [Fact]
    public void Is_Should_ReturnTrue_IfModalVerbEndsWithNt()
    {
        // Arrange
        var shortNegativeForm = new Text("didn't");
        
        // Act
        bool result = ShortNegativeForm.Is(shortNegativeForm);

        // Assert
        result.Should().BeTrue();
    }
}
