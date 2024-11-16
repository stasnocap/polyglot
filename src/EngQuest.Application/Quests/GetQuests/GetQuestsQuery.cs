using EngQuest.Application.Abstractions.Messaging;
using MediatR;

namespace EngQuest.Application.Quests.GetQuests;

public record GetQuestsQuery(string? SearchTerm) : IQuery<IReadOnlyList<QuestResponse>>;
