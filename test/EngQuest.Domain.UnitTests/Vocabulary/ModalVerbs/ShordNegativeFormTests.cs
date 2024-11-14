using FluentAssertions;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.ModalVerbs;

namespace EngQuest.Domain.UnitTests.Vocabulary.ModalVerbs;

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
