using LolBet.Domain.Aggregates.User.Events;
using LolBet.Shared.Domain.Aggregates;

namespace LolBet.Domain.Aggregates.User;

public class UserAggregate : AggregateRoot<UserId>
{
    
    private UserAggregate(UserId id) : base(id)
    {
    }

    public static UserAggregate Create(UserId id)
    {
        var user = new UserAggregate(id);
        
        user.AddDomainEvent(new UserCreatedDomainEvent(user.Id.Value));
        
        return user;
    }

    public static UserAggregate Hydrate(UserId id) => new(id);
}