using EngQuest.Application.Abstractions.Messaging;

namespace EngQuest.Application.Vocabulary.Adjectives.DeleteAdjective;

public record DeleteAdjectiveCommand(int Id) : ICommand;
