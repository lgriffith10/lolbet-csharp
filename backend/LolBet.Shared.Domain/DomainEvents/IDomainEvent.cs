namespace LolBet.Shared.Domain.DomainEvents;

public interface IDomainEvent
{
    Guid AggregateId { get; }
}