namespace Polyglot.Application.Vocabulary.Adjectives.GetAdjectives;

public record AdjectiveResponse
{
    public required Guid Id { get; init; }
    public required string Text { get; init; }
}
