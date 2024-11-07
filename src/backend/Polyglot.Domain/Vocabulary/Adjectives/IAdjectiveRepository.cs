using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Adjectives;

public interface IAdjectiveRepository
{
    Task<Adjective?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<bool> ExistsAsync(Text text, CancellationToken cancellationToken);
    
    void Add(Adjective adjective);
    
    void Delete(Adjective adjective);
}
