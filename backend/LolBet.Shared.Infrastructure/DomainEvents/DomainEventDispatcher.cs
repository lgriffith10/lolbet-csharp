using LolBet.Shared.Domain.DomainEvents;
using Microsoft.Extensions.DependencyInjection;


namespace LolBet.Shared.Infrastructur.DomainEvents;

public class DomainEventDispatcher(IServiceProvider serviceProvider) : IDomainEventDispatcher
{
    public async Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        var eventType = domainEvent.GetType();
        var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(eventType);

        var handlers = serviceProvider.GetServices(handlerType);

        foreach (var handler in handlers)
        {
            var handlerMethod = handlerType.GetMethod(nameof(IDomainEventHandler<IDomainEvent>.HandleAsync)); 
            
            if (handlerMethod is null) throw new InvalidOperationException($"No handler method found for {eventType}");

            var task = (Task)handlerMethod.Invoke(handler, new object[]
            {
                domainEvent, cancellationToken
            })!;

            await task;
        }
    }

    public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        foreach (var domainEvent in domainEvents)
        {
            await DispatchAsync(domainEvent, cancellationToken);
        }
    }
}