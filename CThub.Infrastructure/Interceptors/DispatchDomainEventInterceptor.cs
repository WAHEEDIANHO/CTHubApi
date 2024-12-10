using CThub.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CThub.Infrastructure.Interceptors;

public class DispatchDomainEventInterceptor(IMediator mediator): SaveChangesInterceptor
{
    // public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    // {
    //     DispatchDomainEvent(eventData.Context).GetAwaiter().GetResult();
    //     return base.SavingChanges(eventData, result);
    // }
    //
    // public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
    //     CancellationToken cancellationToken = new CancellationToken())
    // {
    //     await DispatchDomainEvent(eventData.Context);
    //     return await base.SavingChangesAsync(eventData, result, cancellationToken);
    // }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        DispatchDomainEvent(eventData.Context).GetAwaiter().GetResult();
        return base.SavedChanges(eventData, result);
    }

    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        await DispatchDomainEvent(eventData.Context);
        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private async Task DispatchDomainEvent(DbContext? context)
    {
        if (context == null) return;
        
        var aggregates=  context.ChangeTracker.Entries<IAggregate>()
            .Where(a => a.Entity.DomainEvents.Any())
            .Select(a => a.Entity);
        var domainEvents = aggregates
            .SelectMany(a => a.DomainEvents).ToList();
        
        aggregates.ToList().ForEach(a => a.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
        {
            
            Console.WriteLine($"publishing an event {domainEvent.EventType}");
            await mediator.Publish(domainEvent);
        }
    }
}