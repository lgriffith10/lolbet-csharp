using LolBet.Domain.Aggregates.User;
using LolBet.Domain.Repositories;
using LolBet.Shared.Domain.Contracts;
using LolBet.Shared.Domain.DomainEvents;
using LolBet.Shared.Infrastructur.DomainEvents;
using LolBet.Shared.Infrastructure.Persistence.Repositories;

namespace LolBet.Core.Infrastructure.AggregateRepositories;

public class UserAggregateRepository(IUnitOfWork unitOfWork, IDomainEventDispatcher domainEventDispatcher) : EfCoreAggregateRepository<UserAggregate, UserId>(unitOfWork, domainEventDispatcher), IUserAggregateRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public new async Task SaveAsync(UserAggregate aggregate, CancellationToken ct = default)
    {
        await base.SaveAsync(aggregate, ct);
        await _unitOfWork.CommitAsync(ct);
    }
}