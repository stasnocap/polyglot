using System.Linq.Expressions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.Adjectives;

public interface IAdjectiveRepository
{
    Task<Adjective?> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    Task<bool> ExistsAsync(Text text, CancellationToken cancellationToken);
    
    void Add(Adjective adjective);
    
    void Delete(Adjective adjective);
        
    Task<PagedList<TResult>> GetPagedAsync<TEntity, TResult>(
        int page, 
        int pageSize, 
        string? sortColumn, 
        string? sortOrder,
        Expression<Func<TEntity, TResult>> select, 
        CancellationToken cancellationToken);
}
