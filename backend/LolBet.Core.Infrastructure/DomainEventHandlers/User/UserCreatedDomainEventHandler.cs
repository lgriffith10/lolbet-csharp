using LolBet.Domain.Aggregates.User.Events;
using MediatR;

namespace LolBet.Core.Infrastructure.DomainEventHandlers.User;

public class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
{
    public Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine(notification.AggregateId);
        throw new NotImplementedException();
    }
}