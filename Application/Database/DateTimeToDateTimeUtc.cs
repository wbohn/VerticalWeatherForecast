using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace VerticalWeatherForecast.Application.Database
{
    public class DateTimeToDateTimeUtc : ValueConverter<DateTime, DateTime>
    {
        public DateTimeToDateTimeUtc() : base(d => DateTime.SpecifyKind(d, DateTimeKind.Utc), d => d)
        {
        }
    }
}
