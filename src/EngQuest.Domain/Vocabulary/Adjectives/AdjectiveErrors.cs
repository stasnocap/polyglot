using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Vocabulary.Adjectives;

public static class AdjectiveErrors
{
    public static readonly Error NotFound = new("Adjective.NotFound", "Adjective was not found.");
    public static readonly Error AlreadyExists = new("Adjective.AlreadyExists", "Such adjective is already exists.");
}
