using MediatR;

namespace LolBet.Shared.Domain.DomainEvents;

public interface IDomainEvent : INotification
{
    Guid AggregateId { get; }
}