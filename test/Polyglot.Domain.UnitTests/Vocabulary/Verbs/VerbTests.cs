using FluentAssertions;
using Polyglot.Domain.UnitTests.Vocabulary.Nouns;
using Polyglot.Domain.Vocabulary.Nouns;
using Polyglot.Domain.Vocabulary.Verbs;

namespace Polyglot.Domain.UnitTests.Vocabulary.Verbs;

public class VerbTests
{
    [Fact]
    public void CreateIrregularVerb_Should_SetPropertyValue()
    {
        // Act
        var verb = Verb.CreateIrregularVerb(VerbData.Text, VerbData.PastForm, VerbData.PastParticipleForm);

        // Assert
        verb.Text.Should().Be(VerbData.Text);
        verb.PastForm.Should().Be(VerbData.PastForm);
        verb.PastParticipleForm.Should().Be(VerbData.PastParticipleForm);
        verb.IsIrregularVerb.Value.Should().BeTrue();
    }

    [Fact]
    public void CreateCreateIrregularVerb_Should_GeneratePresentParticipleForm()
    {
        // Arrange
        var presentParticipleForm = PresentParticipleForm.From(VerbData.Text, true);

        // Act
        var verb = Verb.CreateIrregularVerb(VerbData.Text, VerbData.PastForm, VerbData.PastParticipleForm);

        // Assert
        verb.PresentParticipleForm.Value.Should().Be(presentParticipleForm.Value);
    }

    [Fact]
    public void CreateCreateIrregularVerb_Should_GenerateThirdPersonForm()
    {
        // Arrange
        var thirdPersonForm = ThirdPersonForm.From(VerbData.Text);

        // Act
        var verb = Verb.CreateIrregularVerb(VerbData.Text, VerbData.PastForm, VerbData.PastParticipleForm);

        // Assert
        verb.ThirdPersonForm.Value.Should().Be(thirdPersonForm.Value);
    }
}
