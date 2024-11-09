namespace Polyglot.Application.Vocabulary.Adjectives.GetAdjectives;

public record AdjectiveResponse
{
    public required int Id { get; init; }
    public required string Text { get; init; }
}
