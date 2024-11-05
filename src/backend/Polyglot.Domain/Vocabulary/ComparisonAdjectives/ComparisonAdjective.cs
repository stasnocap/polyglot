using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.ComparisonAdjectives;

public sealed class ComparisonAdjective : Entity
{
    public Text Text { get; }
    public ComparativeForm ComparativeForm { get; }
    public SuperlativeForm SuperlativeForm { get; }

    public ComparisonAdjective(Guid id, Text text, ComparativeForm comparativeForm, SuperlativeForm superlativeForm) : base(id)
    {
        Text = text;
        ComparativeForm = comparativeForm;
        SuperlativeForm = superlativeForm;
    }
    
    // ReSharper disable once UnusedMember.Local
    private ComparisonAdjective()
    {
    }

    public static ComparisonAdjective Create(Guid comparisonAdjectiveId, Text text, SyllablesCount syllablesCount)
    {
        var comparativeForm = ComparativeForm.From(text, syllablesCount);
        var superlativeForm = SuperlativeForm.From(text, syllablesCount);
        return new ComparisonAdjective(comparisonAdjectiveId, text, comparativeForm, superlativeForm);
    }
}
