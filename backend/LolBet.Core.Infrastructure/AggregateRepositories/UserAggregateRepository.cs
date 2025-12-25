using LolBet.Domain.Aggregates.User;
using LolBet.Domain.Repositories;
using LolBet.Domain.Tables;
using LolBet.Shared.Domain.Contracts;
using LolBet.Shared.Domain.DomainEvents;
using LolBet.Shared.Domain.Persistence;
using LolBet.Shared.Infrastructure.Persistence.Repositories;

namespace LolBet.Core.Infrastructure.AggregateRepositories;

public class UserAggregateRepository(IUnitOfWork unitOfWork, IDomainEventDispatcher domainEventDispatcher, IRawRepository<UserTable> userRepository)
    : EfCoreAggregateRepository<UserAggregate, UserId>(unitOfWork, domainEventDispatcher), IUserAggregateRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public new async Task SaveAsync(UserAggregate aggregate, CancellationToken ct = default)
    {
        var table = new UserTable();

        table.Id = aggregate.Id.Value;

        await userRepository.AddAsync(table, ct);
        
        await base.SaveAsync(aggregate, ct);
    }
}
