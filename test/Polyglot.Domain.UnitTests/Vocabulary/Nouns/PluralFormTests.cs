using FluentAssertions;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.Nouns;

namespace Polyglot.Domain.UnitTests.Vocabulary.Nouns;

public class PluralFormTests
{
    [Fact]
    public void Is_Should_ReturnTrue_IfNounEndsWithS()
    {
        // Arrange
        var pluralForm = new Text("photos");
        
        // Act
        bool result = PluralForm.Is(pluralForm);

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("bus", "buses")]
    [InlineData("truss", "trusses")]
    [InlineData("marsh", "marshes")]
    [InlineData("lunch", "lunches")]
    [InlineData("tax", "taxes")]
    [InlineData("blitz", "blitzes")]
    [InlineData("tomato", "tomatoes")]
    [InlineData("potato", "potatoes")]
    [InlineData("photo", "photos")]
    [InlineData("piano", "pianos")]
    [InlineData("halo", "halos")]
    [InlineData("wolf", "wolves")]
    [InlineData("calf", "calves")]
    [InlineData("leaf", "leaves")]
    [InlineData("wife", "wives")]
    [InlineData("knife", "knives")]
    [InlineData("life", "lives")]
    [InlineData("city", "cities")]
    [InlineData("puppy", "puppies")]
    [InlineData("roof", "roofs")]
    [InlineData("belief", "beliefs")]
    [InlineData("chef", "chefs")]
    [InlineData("chief", "chiefs")]
    [InlineData("analysis", "analyses")]
    [InlineData("ellipsis", "ellipses")]
    [InlineData("phenomenon", "phenomena")]
    [InlineData("criterion", "criteria")]
    public void From_Should_ReturnCorrectPluralForm(string singularNoun, string correct)
    {
        // Arrange
        var singularNounText = new Text(singularNoun);

        // Act
        var pluralForm = PluralForm.From(singularNounText);

        // Assert
        pluralForm.Value.Should().Be(correct);
    }
}
