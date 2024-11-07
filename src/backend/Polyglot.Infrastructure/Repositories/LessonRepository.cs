using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Polyglot.Domain.Lessons;

namespace Polyglot.Infrastructure.Repositories;

[SuppressMessage("Info Code Smell", "S1135:Track uses of \"TODO\" tags")]
internal sealed class LessonRepository(ApplicationDbContext dbContext) : Repository<Lesson>(dbContext), ILessonRepository
{
    public Task<bool> ExistsAsync(Guid lessonId, CancellationToken cancellationToken)
    {
        return DbContext
            .Set<Lesson>()
            .AnyAsync(l => l.Id == lessonId, cancellationToken);
    }
    
    public Task<LessonNumber?> GetLessonNumberAsync(Guid lessonId, CancellationToken cancellationToken)
    {
        return DbContext
            .Set<Lesson>()
            .Where(l => l.Id == lessonId)
            .Select(l => l.Number)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task<Lesson?> GetAsync(Guid lessonId, CancellationToken cancellationToken)
    {
        return DbContext
            .Set<Lesson>()
            .FirstOrDefaultAsync(l => l.Id == lessonId, cancellationToken);
    }

    // TODO: fix this
    public Task<List<Lesson>> GetRangeAsync(Guid? userId, string? searchTerm, CancellationToken cancellationToken)
    {
        return DbContext
            .Set<Lesson>()
            .OrderBy(l => l.Number)
            .ToListAsync(cancellationToken);
    }
}
