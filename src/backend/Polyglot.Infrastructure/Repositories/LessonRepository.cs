using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Polyglot.Domain.Lessons;

namespace Polyglot.Infrastructure.Repositories;

[SuppressMessage("Info Code Smell", "S1135:Track uses of \"TODO\" tags")]
internal sealed class LessonRepository(ApplicationDbContext dbContext) : Repository<Lesson>(dbContext), ILessonRepository
{
    public Task<bool> ExistsAsync(int lessonId, CancellationToken cancellationToken)
    {
        return DbContext
            .Set<Lesson>()
            .AnyAsync(l => l.Id == lessonId, cancellationToken);
    }

    // TODO: fix this
    public Task<List<Lesson>> GetRangeAsync(int? userId, string? searchTerm, CancellationToken cancellationToken)
    {
        return DbContext
            .Set<Lesson>()
            .OrderBy(l => l.Id)
            .ToListAsync(cancellationToken);
    }
}
