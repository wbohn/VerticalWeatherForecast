namespace VerticalWeatherForecast.Application.Common
{
    public class BaseEntity<TId>
    {
        public TId Id { get; set; } = default!;
    }
}
