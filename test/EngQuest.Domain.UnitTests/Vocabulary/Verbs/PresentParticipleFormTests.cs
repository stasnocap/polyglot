using FluentAssertions;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.Verbs;

namespace EngQuest.Domain.UnitTests.Vocabulary.Verbs;

public class PresentParticipleFormTests
{
    [Fact]
    public void Is_Should_ReturnTrue_IfVerbEndsWithIng()
    {
        // Arrange
        var presentParticipleForm = new Text("playing");
        
        // Act
        bool result = PresentParticipleForm.Is(presentParticipleForm);

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("listen", "listening")]
    [InlineData("follow", "following")]
    [InlineData("bake", "baking")]
    [InlineData("eliminate", "eliminating")]
    [InlineData("die", "dying")]
    [InlineData("lie", "lying")]
    [InlineData("watch", "watching")]
    [InlineData("discover", "discovering")]
    [InlineData("hit", "hitting", true)]
    [InlineData("begin", "beginning", true)]
    public void From_Should_ReturnCorrectParticipleForm(string verb, string correct, bool stressOnTheFinalSyllable = false)
    {
        // Arrange
        var verbText = new Text(verb);

        // Act
        var presentParticipleForm = PresentParticipleForm.From(verbText, stressOnTheFinalSyllable);
        
        // Arrange
        presentParticipleForm.Value.Should().Be(correct);
    }
}
