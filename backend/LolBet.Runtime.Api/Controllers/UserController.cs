using System.Net;
using LolBet.Core.Application.User.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LolBet.Runtime.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IMediator mediator)
{
    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType(typeof(CreateUserResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(CreateUserResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<CreateUserResponse> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }
}