using EngQuest.Application.Abstractions.Messaging;

namespace EngQuest.Application.Vocabulary.Adjectives.UpdateAdjective;

public record UpdateAdjectiveCommand(int Id, string Text) : ICommand;
