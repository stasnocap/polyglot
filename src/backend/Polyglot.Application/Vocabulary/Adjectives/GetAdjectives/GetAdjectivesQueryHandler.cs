using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary;
using Polyglot.Domain.Vocabulary.Adjectives;

namespace Polyglot.Application.Vocabulary.Adjectives.GetAdjectives;

public class GetAdjectivesQueryHandler(IVocabularyRepository _repository) : IQueryHandler<GetAdjectivesQuery, PagedList<AdjectiveResponse>>
{
    public async Task<Result<PagedList<AdjectiveResponse>>> Handle(GetAdjectivesQuery request, CancellationToken cancellationToken)
    {
        if (request.Page <= 0 || request.PageSize <= 0)
        {
            return PagedList<AdjectiveResponse>.Empty();
        }
        
        PagedList<AdjectiveResponse> result = await _repository.GetPagedAsync<Adjective, AdjectiveResponse>(
            request.Page, 
            request.PageSize,
            request.SortColumn, 
            request.SortOrder,
            a => new AdjectiveResponse
            {
                Id = a.Id,
                Text = a.Text,
            },
            cancellationToken);

        return result;
    }
}
