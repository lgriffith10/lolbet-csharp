using LolBet.Shared.Domain.DomainEvents;
using MediatR;

namespace LolBet.Shared.Infrastructure.DomainEvents;

public class DomainEventDispatcher(IMediator mediator) : IDomainEventDispatcher
{
    public async Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        await mediator.Publish(domainEvent, cancellationToken);
    }

    public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        foreach (var domainEvent in domainEvents)
        {
            await DispatchAsync(domainEvent, cancellationToken);
        }
    }
}