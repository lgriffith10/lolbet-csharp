using MediatR;

namespace LolBet.Core.Application.WeatherForecast.GetWeatherForecast;

public record GetWeatherForecastRequest : IRequest<GetWeatherForecastResponse>
{
}