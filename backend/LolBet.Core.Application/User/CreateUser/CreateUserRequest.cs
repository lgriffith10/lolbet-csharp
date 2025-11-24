using MediatR;

namespace LolBet.Core.Application.User.CreateUser;

public record CreateUserRequest : IRequest<CreateUserResponse>
{
    public Guid UserId { get; init; }
}