using FluentAssertions;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.Verbs;

namespace Polyglot.Domain.UnitTests.Vocabulary.Verbs;

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
