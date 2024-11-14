using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Vocabulary.Nouns;

public static class NounErrors
{
    public static readonly Error EmptyPluralFormForm = new("Noun.EmptyPluralForm", "Plural form can't be empty.");
}
