using LolBet.Domain.Aggregates.User;
using LolBet.Domain.Repositories;
using MediatR;

namespace LolBet.Core.Application.User.CreateUser;

public class CreateUserHandler(IUserAggregateRepository userAggregateRepository) : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        // Handler

        var userId = UserId.Create(request.UserId);
        var user = UserAggregate.Create(userId);

        await userAggregateRepository.SaveAsync(user, cancellationToken);

        return new CreateUserResponse(userId.Value);
    }
}