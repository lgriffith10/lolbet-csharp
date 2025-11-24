namespace LolBet.Core.Application.User.CreateUser;

public record CreateUserResponse(Guid userId)
{
    public Guid UserId { get; } = userId;
}