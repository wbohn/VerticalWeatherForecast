using Microsoft.EntityFrameworkCore;
using VerticalWeatherForecast.Application.WeatherForecasts;

namespace VerticalWeatherForecast.Application.Database
{
    public interface IApplicationDbContext
    {
        DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
