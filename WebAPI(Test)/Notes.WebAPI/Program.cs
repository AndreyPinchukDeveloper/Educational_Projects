using Microsoft.Extensions.Hosting;
using Notes.Application.Common.Mapping;
using Notes.Application.Interfaces;
using Notes.Persistance;
using System.Reflection;

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

app.MapGet("/", () => "Hello World!");

app.Run();
