namespace LolBet.Domain.Aggregates.User.Builders;

public class UserBuilder
{
    private readonly UserAggregate _blueprint;

    private UserBuilder(UserAggregate blueprint)
    {
        this._blueprint = blueprint;
    }

    public static UserBuilder Create()
    {
        return new UserBuilder(blueprint: UserAggregate.Create(UserId.Hydrate(Guid.NewGuid())));
    }

    public UserBuilder WithId(UserId id)
    {
        _blueprint.Id = id;
        return this;
    }

    public UserAggregate Get() => _blueprint;
}