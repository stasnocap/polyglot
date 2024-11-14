using EngQuest.Application.Abstractions.Messaging;
using EngQuest.Domain.Shared;

namespace EngQuest.Application.Vocabulary.Adjectives.GetAdjectives;

public record GetAdjectivesQuery(int Page, int PageSize, string? SortColumn, string? SortOrder) : IQuery<PagedList<AdjectiveResponse>>;
