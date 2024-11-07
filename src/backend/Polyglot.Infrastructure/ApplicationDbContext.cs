using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Polyglot.Application.Abstractions.Clock;
using Polyglot.Application.Exceptions;
using Polyglot.Domain.Abstractions;
using Polyglot.Infrastructure.Outbox;

namespace Polyglot.Infrastructure;

public sealed class ApplicationDbContext(
    DbContextOptions options,
    IDateTimeProvider dateTimeProvider) : DbContext(options), IUnitOfWork
{
    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All
    };

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            AddDomainEventsAsOutboxMessages();

            int result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency exception occurred.", ex);
        }
    }

    private void AddDomainEventsAsOutboxMessages()
    {
        var outboxMessages = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                IReadOnlyCollection<IDomainEvent> domainEvents = entity.GetDomainEvents();

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .Select(domainEvent => new OutboxMessage(
                Guid.NewGuid(),
                dateTimeProvider.UtcNow,
                domainEvent.GetType().Name,
                JsonConvert.SerializeObject(domainEvent, JsonSerializerSettings)))
            .ToList();

        AddRange(outboxMessages);
    }
    
                
    [SuppressMessage("Usage", "EF1001:Internal EF Core API usage.")]
    [SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields")]
    public IQueryable<object> GetAll(Type type)
    {
        MethodInfo setSource = GetType() .GetMethod("Microsoft.EntityFrameworkCore.Internal.IDbContextDependencies.get_SetSource", BindingFlags.NonPublic | BindingFlags.Instance)!;

        return (IQueryable<object>)((IDbSetCache)this).GetOrAddSet((IDbSetSource)setSource.Invoke(this, null!)!, type);
    }
}
