using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Middleware.Extensions;
using WebAPI.Services;
using WebAPI.Services.Tests;
using WebAPI.Services.Tests.Intefaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IScopedService, TestService>();
builder.Services.AddTransient<ITransientService, TestService>();
builder.Services.AddSingleton<ISingletonService, TestService>();
builder.Services.AddTransient<DataBaseServiceTest>();
builder.Services.AddTransient<IOrderService, OrderService>();

var app = builder.Build();
app.UseLogUrl();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();//that method always must be at the end  

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
