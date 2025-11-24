using LolBet.Shared.Domain.Aggregates;
using LolBet.Shared.Domain.Contracts;
using LolBet.Shared.Domain.DomainEvents;
using LolBet.Shared.Domain.Persistence;

namespace LolBet.Shared.Infrastructure.Persistence.Repositories;

public class EfCoreAggregateRepository<TAggregate, TId>(IUnitOfWork unitOfWork, IDomainEventDispatcher domainEventDispatcher)
    : IAggregateRepository<TAggregate, TId>
    where TAggregate : AggregateRoot<TId>
    where TId : notnull
{
    
    public async Task SaveAsync(TAggregate aggregate, CancellationToken ct = default)
    {
        await unitOfWork.SaveChangesAsync(ct);
        
        await domainEventDispatcher.DispatchAsync(aggregate.DomainEvents, ct);
        
        await unitOfWork.SaveChangesAsync(ct);
    }
}