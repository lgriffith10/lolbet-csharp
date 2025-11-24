namespace LolBet.Domain.Aggregates.User;

public class UserId
{
    public Guid Value { get; }
    
    private UserId(Guid value)
    {
        Value = value;
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