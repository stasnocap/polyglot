using FluentAssertions;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.Verbs;

namespace Polyglot.Domain.UnitTests.Vocabulary.Verbs;

public class ThirdPersonFormTests
{
    [Fact]
    public void Is_Should_ReturnTrue_IfVerbEndsWithS()
    {
        // Arrange
        var thirdPersonForm = new Text("gives");
        
        // Act
        bool result = ThirdPersonForm.Is(thirdPersonForm);

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("watch", "watches")]
    [InlineData("miss", "misses")]
    [InlineData("rush", "rushes")]
    [InlineData("relax", "relaxes")]
    [InlineData("buzz", "buzzes")]
    [InlineData("try", "tries")]
    [InlineData("apply", "applies")]
    [InlineData("sing", "sings")]
    [InlineData("give", "gives")]
    [InlineData("require", "requires")]
    public void From_Should_ReturnCorrectPersonForm(string verb, string correct)
    {
        // Arrange
        var verbText = new Text(verb);

        // Act
        var presentParticipleForm = ThirdPersonForm.From(verbText);
        
        // Arrange
        presentParticipleForm.Value.Should().Be(correct);
    }
}
