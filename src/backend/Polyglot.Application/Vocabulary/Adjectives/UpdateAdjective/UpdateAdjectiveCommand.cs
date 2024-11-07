using Polyglot.Application.Abstractions.Messaging;

namespace Polyglot.Application.Vocabulary.Adjectives.UpdateAdjective;

public record UpdateAdjectiveCommand(Guid Id, string Text) : ICommand;
