using FluentAssertions;
using Polyglot.Domain.Vocabulary.Nouns;

namespace Polyglot.Domain.UnitTests.Vocabulary.Nouns;

public class NounTests
{
    [Fact]
    public void Create_Should_SetPropertyValue()
    {
        // Act
        var noun = Noun.Create(NounData.Text, NounData.NounType);
        
        // Assert
        noun.Text.Should().Be(NounData.Text);
        noun.Type.Should().Be(NounData.NounType);
    }

    [Fact]
    public void Create_Should_GeneratePluralForm()
    {
        // Arrange
        var pluralForm = PluralForm.From(NounData.Text);

        // Act
        var noun = Noun.Create(NounData.Text, NounData.NounType);
        
        // Assert
        noun.PluralForm.Value.Should().Be(pluralForm.Value);
    }
}
