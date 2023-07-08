using Microsoft.Extensions.Hosting;
using Notes.Application;
using Notes.Application.Common.Mapping;
using Notes.Application.Interfaces;
using Notes.Persistance;
using System.Reflection;

public IConfiguration Configuration { get; }


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
	try
	{
		var context = serviceProvider.GetRequiredService<NotesDbContext>();
		DbInitializer.Initialize(context);
	}
	catch (Exception)
	{

		throw;
	}
}

builder.Services.AddAutoMapper(config =>
{
	config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
	config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddPersistance();//!!!!!

builder.Services.AddCors(options =>//only for tests !!!!
{
	options.AddPolicy("AllowAll", policy =>
	{
		policy.AllowAnyHeader();
		policy.AllowAnyMethod();
		policy.AllowAnyOrigin();
	});
});

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");//only for tests !!!!

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});


app.MapGet("/", () => "Hello World!");

app.Run();
