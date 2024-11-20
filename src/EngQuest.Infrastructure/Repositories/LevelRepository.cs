using EngQuest.Domain.Levels;
using Microsoft.EntityFrameworkCore;

namespace EngQuest.Infrastructure.Repositories;

public class LevelRepository(ApplicationDbContext dbContext) : Repository<Level>(dbContext), ILevelRepository
{
    public Task<Level?> GetByUserIdAsync(int userId, CancellationToken cancellationToken)
    {
        return DbContext
            .Set<Level>()
            .FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
    }
}
