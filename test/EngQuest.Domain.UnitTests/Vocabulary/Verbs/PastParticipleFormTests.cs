using FluentAssertions;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.Verbs;

namespace EngQuest.Domain.UnitTests.Vocabulary.Verbs;

public class PastParticipleFormTests
{
    [Fact]
    public void Is_Should_ReturnTrueIfVerbEndsWithEd()
    {
        // Arrange
        var pastParticipleForm = new Text("played");
        
        // Act
        bool result = PastParticipleForm.Is(pastParticipleForm);

        // Assert
        result.Should().BeTrue();
    }
}
