using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Vocabulary.ComparisonAdjectives;

public static class ComparisonAdjectiveErrors
{
    public static readonly Error EmptyComparisionAdjectiveText = new("ComparisonAdjective.EmptyComparisionAdjectiveText", "Comparative adjective text can't be empty.");
    public static readonly Error EmptyComparativeForm = new("ComparisonAdjective.EmptyComparativeForm", "Comparative form can't be empty.");
    public static readonly Error EmptySuperlativeForm = new("ComparisonAdjective.EmptySuperlativeForm", "Superlative form can't be empty.");
    public static readonly Error SyllablesCountNegative = new("ComparisonAdjective.CountOfSyllablesNegative", "Count of syllables can't be negative or zero.");
}
