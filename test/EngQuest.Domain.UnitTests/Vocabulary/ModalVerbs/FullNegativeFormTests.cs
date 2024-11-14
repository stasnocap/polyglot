using FluentAssertions;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.ModalVerbs;

namespace EngQuest.Domain.UnitTests.Vocabulary.ModalVerbs;

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
