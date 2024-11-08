using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.ComparisonAdjectives;

public sealed class ComparisonAdjective
{
    public int Id { get; init; }
    public Text Text { get; }
    public ComparativeForm ComparativeForm { get; }
    public SuperlativeForm SuperlativeForm { get; }

    public ComparisonAdjective(Text text, ComparativeForm comparativeForm, SuperlativeForm superlativeForm)
    {
        Text = text;
        ComparativeForm = comparativeForm;
        SuperlativeForm = superlativeForm;
    }
    
    // ReSharper disable once UnusedMember.Local
    private ComparisonAdjective()
    {
    }

    public static ComparisonAdjective Create(int comparisonAdjectiveId, Text text, SyllablesCount syllablesCount)
    {
        var comparativeForm = ComparativeForm.From(text, syllablesCount);
        var superlativeForm = SuperlativeForm.From(text, syllablesCount);
        
        return new ComparisonAdjective(text, comparativeForm, superlativeForm)
        {
            Id = comparisonAdjectiveId
        };
    }
}
