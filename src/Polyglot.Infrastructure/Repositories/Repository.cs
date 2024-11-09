using Microsoft.EntityFrameworkCore;

namespace Polyglot.Infrastructure.Repositories;

public abstract class Repository<T>(ApplicationDbContext dbContext) where T : class
{
    protected readonly ApplicationDbContext DbContext = dbContext;

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<T>()
            .FirstOrDefaultAsync(user => EF.Property<int>(user, "Id") == id, cancellationToken);
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
