using Polyglot.Application.Abstractions.Messaging;

namespace Polyglot.Application.Vocabulary.Adjectives.DeleteAdjective;

public record DeleteAdjectiveCommand(Guid Id) : ICommand;
