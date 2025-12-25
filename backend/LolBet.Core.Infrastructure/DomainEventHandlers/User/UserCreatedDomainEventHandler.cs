using LolBet.Domain.Aggregates.User.Events;
using LolBet.Domain.Tables;
using LolBet.Shared.Domain.Persistence;
using MediatR;

namespace LolBet.Core.Infrastructure.DomainEventHandlers.User;

public sealed class UserCreatedDomainEventHandler(IRawRepository<UserTable> userRepository) : INotificationHandler<UserCreatedDomainEvent>
{
    public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var table = new UserTable
        {
            Id = Guid.NewGuid()
        };

        await userRepository.AddAsync(table, cancellationToken); 
    }
}