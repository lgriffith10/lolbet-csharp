using LolBet.Shared.Domain.Aggregates;

namespace LolBet.Shared.Domain.Persistence;

public interface IAggregateRepository<TAggregate, TId>
    where TAggregate : AggregateRoot<TId>
    where TId : notnull
{
    Task SaveAsync(TAggregate aggregate, CancellationToken ct = default);
}