using LolBet.Domain.Aggregates.User;
using LolBet.Domain.Repositories;
using LolBet.Shared.Domain.Contracts;
using LolBet.Shared.Domain.DomainEvents;
using LolBet.Shared.Infrastructure.Persistence.Repositories;

namespace LolBet.Core.Infrastructure.AggregateRepositories;

public class UserAggregateRepository : EfCoreAggregateRepository<UserAggregate, UserId>, IUserAggregateRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public UserAggregateRepository(IUnitOfWork unitOfWork, IDomainEventDispatcher domainEventDispatcher)
        : base(unitOfWork, domainEventDispatcher)
    {
        _unitOfWork = unitOfWork;
    }

    public new async Task SaveAsync(UserAggregate aggregate, CancellationToken ct = default)
    {
        await base.SaveAsync(aggregate, ct);
        await _unitOfWork.CommitAsync(ct);
    }
}
