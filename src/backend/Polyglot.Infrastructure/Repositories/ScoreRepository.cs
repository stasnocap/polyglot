using Microsoft.EntityFrameworkCore;
using Polyglot.Domain.Scores;

namespace Polyglot.Infrastructure.Repositories;

public class ScoreRepository(ApplicationDbContext dbContext) : Repository<Score>(dbContext), IScoreRepository
{
    public Task<Score?> GetAsync(Guid lessonId, Guid userId, CancellationToken cancellationToken)
    {
        return DbContext.Set<Score>().FirstOrDefaultAsync(s => s.LessonId == lessonId && s.UserId == userId, cancellationToken);
    }
}
