using System.Linq.Expressions;
using Polyglot.Domain.Exercises;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary;

public interface IVocabularyRepository
{
    Task<List<string>> GetRandomAsync(Word word, int count, CancellationToken cancellationToken);
    
    Task<PagedList<TResult>> GetPagedAsync<TEntity, TResult>(
        int page, 
        int pageSize, 
        string? sortColumn, 
        string? sortOrder,
        Expression<Func<TEntity, TResult>> select, 
        CancellationToken cancellationToken);

    Task AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken);
    
    ValueTask<TEntity?> GetAsync<TEntity>(Guid id, CancellationToken cancellationToken);
    
    void Delete<TEntity>(TEntity entity);
}
