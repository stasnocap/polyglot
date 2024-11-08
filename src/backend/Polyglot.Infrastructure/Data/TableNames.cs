using Polyglot.Domain.Lessons.Exercises;

namespace Polyglot.Infrastructure.Data;

public static class TableNames
{
    public static string GetTableName(WordType wordType)
    {
        return wordType switch
        {
            WordType.Adjective => "adjectives",
            WordType.Adverb => "adverbs",
            WordType.City => "cities",
            WordType.ComparisonAdjective => "comparison_adjectives",
            WordType.Compound => "compounds",
            WordType.Determiner => "determiners",
            WordType.Language => "languages",
            WordType.LetterNumber => "letter_numbers",
            WordType.ModalVerb => "modal_verbs",
            WordType.Noun => "nouns",
            WordType.NumberWithNoun => "number_with_nouns",
            WordType.Preposition => "prepositions",
            WordType.PrimaryVerb => "primary_verbs",
            WordType.Pronoun => "pronouns",
            WordType.QuestionWord => "question_words",
            WordType.Verb => "verbs",
            _ => throw new ArgumentOutOfRangeException(nameof(wordType), wordType, null)
        };
    }
}
