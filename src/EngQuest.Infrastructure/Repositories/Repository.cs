using EngQuest.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EngQuest.Infrastructure.Repositories;

public abstract class Repository<T>(ApplicationDbContext dbContext) where T : Entity
{
    protected readonly ApplicationDbContext DbContext = dbContext;

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public virtual void Add(T entity)
    {
        DbContext.Add(entity);
    }

    public virtual void Delete(T entity)
    {
        DbContext.Remove(entity);
    }
}
