using LolBet.Shared.Domain.DomainEvents;

namespace LolBet.Domain.Aggregates.User.Events;

public class UserCreatedDomainEvent(Guid aggregateId) : IDomainEvent
{
    public Guid AggregateId { get; } = aggregateId;
}