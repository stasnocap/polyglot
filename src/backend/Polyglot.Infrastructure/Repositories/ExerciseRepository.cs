using Microsoft.EntityFrameworkCore;
using Polyglot.Domain.Exercises;

namespace Polyglot.Infrastructure.Repositories;

internal sealed class ExerciseRepository(ApplicationDbContext dbContext) : Repository<Exercise>(dbContext), IExerciseRepository
{
    public Task<Exercise> GetRandomAsync(Guid lessonId, CancellationToken cancellationToken)
    {
        return DbContext
            .Set<Exercise>()
            .AsNoTracking()
            .Where(e =>  e.LessonIds.Contains(lessonId))
            .OrderBy(x => Guid.NewGuid())
            .FirstAsync(cancellationToken);
    }

    public Task<Exercise?> GetAsync(Guid exerciseId, CancellationToken cancellationToken)
    {
        return DbContext
            .Set<Exercise>()
            .AsNoTracking()
            .Where(e =>  e.Id == exerciseId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task<string?> GetAnswerAsync(Guid exerciseId, CancellationToken cancellationToken)
    {
        return DbContext
            .Set<Exercise>()
            .AsNoTracking()
            .Where(e => e.Id == exerciseId)
            .Select(e => string.Join(' ', e.Words.OrderBy(w => (int)w.Number).Select(w => (string)w.Text)))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
