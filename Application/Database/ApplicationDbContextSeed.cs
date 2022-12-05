using Microsoft.EntityFrameworkCore;
using VerticalWeatherForecast.Application.WeatherForecasts;

namespace VerticalWeatherForecast.Application.Database
{
    public class ApplicationDbContextSeed
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", 
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (!await dbContext.WeatherForecasts.AnyAsync())
            {
                await dbContext.WeatherForecasts.AddRangeAsync(
                    GetInitialWeatherForecasts());

                await dbContext.SaveChangesAsync();
            }
        }

        static IEnumerable<WeatherForecast> GetInitialWeatherForecasts()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }
}
