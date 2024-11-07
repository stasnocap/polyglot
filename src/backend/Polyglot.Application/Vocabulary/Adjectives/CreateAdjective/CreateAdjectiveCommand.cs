using Polyglot.Application.Abstractions.Messaging;

namespace Polyglot.Application.Vocabulary.Adjectives.CreateAdjective;

public record CreateAdjectiveCommand(string Text) : ICommand<Guid>;
