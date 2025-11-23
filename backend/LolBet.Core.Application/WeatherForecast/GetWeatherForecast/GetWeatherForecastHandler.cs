using MediatR;

namespace LolBet.Core.Application.WeatherForecast.GetWeatherForecast;

public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastRequest, GetWeatherForecastResponse>
{
    public async Task<GetWeatherForecastResponse> Handle(GetWeatherForecastRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Hello world");

        return new GetWeatherForecastResponse();
    }
}