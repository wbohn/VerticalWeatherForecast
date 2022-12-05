using Microsoft.OpenApi.Models;
using VerticalWeatherForecast.Application.Database;
using VerticalWeatherForecast.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "VerticalWeatherForecast", Version = "v1" });
    options.CustomSchemaIds(type => type.Name.EndsWith("Dto") ? type.Name.Replace("Dto", string.Empty) : type.Name);
});


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();


using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    var dbContext = scopedProvider.GetRequiredService<ApplicationDbContext>();
    await ApplicationDbContextSeed.SeedAsync(dbContext);
}

app.Run();
