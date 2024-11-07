using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Shared;

namespace Polyglot.Application.Vocabulary.Adjectives.GetAdjectives;

public record GetAdjectivesQuery(int Page, int PageSize, string? SortColumn, string? SortOrder) : IQuery<PagedList<AdjectiveResponse>>;
