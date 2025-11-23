using LolBet.Core.Application.WeatherForecast.GetWeatherForecast;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LolBet.Runtime.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IMediator mediator)
{
    [HttpGet]
    [Route("[action]")]
    [ProducesResponseType(typeof(GetWeatherForecastResponse), 200)]
    [ProducesResponseType(typeof(GetWeatherForecastResponse), 400)]
    public async Task<GetWeatherForecastResponse> GetWeatherForecast(CancellationToken cancellationToken)
    {
        var request = new GetWeatherForecastRequest();
        return await mediator.Send(request, cancellationToken);
    }
}