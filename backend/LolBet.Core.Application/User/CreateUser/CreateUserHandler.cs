using LolBet.Domain.Aggregates.User;
using LolBet.Domain.Repositories;
using LolBet.Shared.Domain.Contracts;
using MediatR;

namespace LolBet.Core.Application.User.CreateUser;

public class CreateUserHandler(IUserAggregateRepository userAggregateRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        // Handler

        await unitOfWork.BeginTransactionAsync(cancellationToken);

        var userId = UserId.Create(request.UserId);
        var user = UserAggregate.Create(userId);

        await userAggregateRepository.SaveAsync(user, cancellationToken);

        await unitOfWork.CommitAsync(cancellationToken);

        return new CreateUserResponse(userId.Value);
    }
}