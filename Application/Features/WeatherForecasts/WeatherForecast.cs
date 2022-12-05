using VerticalWeatherForecast.Application.Common;
namespace VerticalWeatherForecast.Application.WeatherForecasts
{
    public class WeatherForecast : BaseEntity<int>
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; } = null!;
    }
}