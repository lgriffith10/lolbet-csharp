using LolBet.Domain.Aggregates.Common;

namespace LolBet.Domain.Aggregates.User;

public class UserId : SimpleValueObject<Guid>
{
    
    private UserId(Guid value) : base(value)
    {
    }

    public static UserId Create(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty", nameof(id));
        }

        return new UserId(id);
    }

    public static UserId Hydrate(Guid id) => new(id);
}