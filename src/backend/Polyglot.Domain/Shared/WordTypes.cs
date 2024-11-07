using Polyglot.Domain.Exercises;
using Polyglot.Domain.Vocabulary.Adjectives;
using Polyglot.Domain.Vocabulary.Adverbs;
using Polyglot.Domain.Vocabulary.Cities;
using Polyglot.Domain.Vocabulary.ComparisonAdjectives;
using Polyglot.Domain.Vocabulary.Compounds;
using Polyglot.Domain.Vocabulary.Determiners;
using Polyglot.Domain.Vocabulary.Languages;
using Polyglot.Domain.Vocabulary.LetterNumbers;
using Polyglot.Domain.Vocabulary.ModalVerbs;
using Polyglot.Domain.Vocabulary.Nouns;
using Polyglot.Domain.Vocabulary.NumberWithNouns;
using Polyglot.Domain.Vocabulary.Prepositions;
using Polyglot.Domain.Vocabulary.PrimaryVerbs;
using Polyglot.Domain.Vocabulary.Pronouns;
using Polyglot.Domain.Vocabulary.QuestionWords;
using Polyglot.Domain.Vocabulary.Verbs;

namespace Polyglot.Domain.Shared;

public static class WordTypes
{
    public static Type GetWordType(WordType type) => type switch
    {
        WordType.Adjective => typeof(Adjective),
        WordType.Adverb => typeof(Adverb),
        WordType.City => typeof(City),
        WordType.ComparisonAdjective => typeof(ComparisonAdjective),
        WordType.Compound => typeof(Compound),
        WordType.Determiner => typeof(Determiner),
        WordType.Language => typeof(Language),
        WordType.LetterNumber => typeof(LetterNumber),
        WordType.ModalVerb => typeof(ModalVerb),
        WordType.Noun => typeof(Noun),
        WordType.NumberWithNoun => typeof(NumberWithNoun),
        WordType.Preposition => typeof(Preposition),
        WordType.PrimaryVerb => typeof(PrimaryVerb),
        WordType.Pronoun => typeof(Pronoun),
        WordType.QuestionWord => typeof(QuestionWord),
        WordType.Verb => typeof(Verb),
        WordType.None => throw new ArgumentOutOfRangeException(nameof(type), type, null),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
    };
}
