using FluentAssertions;
using Polyglot.Domain.Lessons.Exercises;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.UnitTests.Lessons.Exercises;

public class WordDecoratorServiceTests
{
    [Fact]
    public void Decorate_Should_MakeFirstLetterUpperCase_IfWordHasFirstLetterUppercased()
    {
        var word = new Word(WordData.WordNumber, new Text("My"), WordType.Adjective);
        var words = new List<string>()
        {
            "old",
            "new",
            "granny",
        };
        
        WordDecoratorService.Decorate(word, words);
        
        foreach (string w in words)
        {
            char.IsUpper(w[0]).Should().BeTrue();
        }
    }
    
    [Fact]
    public void Decorate_Should_AppendNonWordSymbol_IfWordHasNonWordSymbolAtTheEnd()
    {
        var word = new Word(WordData.WordNumber, new Text("my."), WordType.Adjective);
        var words = new List<string>()
        {
            "old",
            "new",
            "granny",
        };
        
        WordDecoratorService.Decorate(word, words);
        
        foreach (string w in words)
        {
            (w[^1] == '.').Should().BeTrue();
        }
    }
    
    [Fact]
    public void Decorate_Should_DoNothing_IfWordHasNonWordSymbolInTheMiddle()
    {
        var word = new Word(WordData.WordNumber, new Text("didn't"), WordType.Adjective);
        var source = new List<string>()
        {
            "old",
            "new",
            "granny",
        };
        
        var decorated = new List<string>()
        {
            "old",
            "new",
            "granny",
        };
        
        WordDecoratorService.Decorate(word, decorated);

        source.SequenceEqual(decorated).Should().BeTrue();
    }
}
