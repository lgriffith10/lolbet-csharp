using LolBet.Domain.Aggregates.User;
using LolBet.Shared.Domain.Persistence;

namespace LolBet.Domain.Repositories;

public interface IUserAggregateRepository : IAggregateRepository<UserAggregate, UserId>
{
}