var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HotelDb>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});
builder.Services.AddScoped<IRepository<HotelDb>, SQLHotelRepository>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<HotelDb>();
    db.Database.EnsureCreated();
}

app.MapGet("/hotels", async (IRepository<HotelDb> repository) => 
    Results.Ok(await repository.GetHotelAsync()));//GET method
app.MapGet("/hotels/{id}", async (int id, IRepository<HotelDb> repository) => 
    await repository.GetHotelAsync(id)
    is Hotel hotel 
    ? Results.Ok(hotel)
    : Results.NotFound());//gets by id

app.MapPost("/hotels", async ([FromBody] Hotel hotel, IRepository<HotelDb> repository) => 
{
    await repository.InsertHotelAsync(hotel);
    await repository.SaveAsync();
    return Results.Created($"/hotels/{hotel.Id}", hotel);
});

app.MapPut("/hotels", async ([FromBody] Hotel hotel, IRepository<HotelDb> repository) => {
    await repository.UpdateHotelAsync(hotel);
    await repository.SaveAsync();
    return Results.NoContent();
});//method for change data from list

app.MapDelete("/hotels/{id}", async (int id, IRepository<HotelDb> repository) => {
    await repository.DeleteHotelAsync(id);
    await repository.SaveAsync();
    return Results.NoContent();
});//method for remove data from list

app.UseHttpsRedirection();//http to https
app.Run();
