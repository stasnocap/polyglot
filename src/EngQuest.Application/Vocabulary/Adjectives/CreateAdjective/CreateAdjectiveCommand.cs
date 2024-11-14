using EngQuest.Application.Abstractions.Messaging;

namespace EngQuest.Application.Vocabulary.Adjectives.CreateAdjective;

public record CreateAdjectiveCommand(string Text) : ICommand<int>;
