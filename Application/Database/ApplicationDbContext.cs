using Microsoft.EntityFrameworkCore;
using VerticalWeatherForecast.Application.WeatherForecasts;

namespace VerticalWeatherForecast.Application.Database
{
    public class ApplicationDbContext :DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<DateTime>()
                .HaveConversion(typeof(DateTimeToDateTimeUtc));
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
