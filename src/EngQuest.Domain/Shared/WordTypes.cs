using EngQuest.Domain.Quests.Objectives;
using EngQuest.Domain.Vocabulary.Adjectives;
using EngQuest.Domain.Vocabulary.Adverbs;
using EngQuest.Domain.Vocabulary.Cities;
using EngQuest.Domain.Vocabulary.ComparisonAdjectives;
using EngQuest.Domain.Vocabulary.Compounds;
using EngQuest.Domain.Vocabulary.Determiners;
using EngQuest.Domain.Vocabulary.Languages;
using EngQuest.Domain.Vocabulary.LetterNumbers;
using EngQuest.Domain.Vocabulary.ModalVerbs;
using EngQuest.Domain.Vocabulary.Nouns;
using EngQuest.Domain.Vocabulary.NumberWithNouns;
using EngQuest.Domain.Vocabulary.Prepositions;
using EngQuest.Domain.Vocabulary.PrimaryVerbs;
using EngQuest.Domain.Vocabulary.Pronouns;
using EngQuest.Domain.Vocabulary.QuestionWords;
using EngQuest.Domain.Vocabulary.Verbs;

namespace EngQuest.Domain.Shared;

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
