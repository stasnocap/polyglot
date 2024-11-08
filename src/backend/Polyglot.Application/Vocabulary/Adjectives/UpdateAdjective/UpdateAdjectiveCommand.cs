using Polyglot.Application.Abstractions.Messaging;

namespace Polyglot.Application.Vocabulary.Adjectives.UpdateAdjective;

public record UpdateAdjectiveCommand(int Id, string Text) : ICommand;
