using LolBet.Domain.Aggregates.User;
using LolBet.Domain.Aggregates.User.Events;
using LolBet.Shared.Domain.DomainEvents;

namespace LolBet.Core.Infrastructure.DomainEventHandlers.User;

public class UserCreatedDomainEventHandler : IDomainEventHandler<UserCreatedDomainEvent>
{
    public Task HandleAsync(UserCreatedDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        Console.WriteLine(domainEvent.AggregateId);
        throw new NotImplementedException();
    }
}