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

builder.Services.AddHealthChecksUI().AddInMemoryStorage();
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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    //endpoints.MapHealthChecks("I'm healthy");
    endpoints.MapHealthChecksUI();
});

app.Run();
