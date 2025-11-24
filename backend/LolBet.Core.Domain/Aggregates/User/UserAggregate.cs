using LolBet.Shared.Domain.Aggregates;

namespace LolBet.Domain.Aggregates.User;

public class UserAggregate : AggregateRoot<UserId>
{
    
    private UserAggregate(UserId id) : base(id)
    {
    }

    public static UserAggregate Create(UserId id)
    {
        return new UserAggregate(id);
    }

    public static UserAggregate Hydrate(UserId id) => new(id);
}