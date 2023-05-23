var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HotelDb>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});
builder.Services.AddScoped<IRepository<HotelDb>, SQLHotelRepository>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<HotelDb>();
    db.Database.EnsureCreated();
}

app.MapGet("/hotels", async (IRepository<HotelDb> repository) => 
    Results.Ok(await repository.GetHotelAsync()))
    .Produces<List<Hotel>>(StatusCodes.Status200OK)
    .WithName("GetAllHotels")
    .WithTags("Getters");//GET method

app.MapGet("/hotels/{id}", async (int id, IRepository<HotelDb> repository) => 
    await repository.GetHotelAsync(id)
    is Hotel hotel 
    ? Results.Ok(hotel)
    : Results.NotFound())
    .WithName("GetHotel")
    .WithTags("Getters");//gets by id

app.MapPost("/hotels", async ([FromBody] Hotel hotel, IRepository<HotelDb> repository) => 
{
    await repository.InsertHotelAsync(hotel);
    await repository.SaveAsync();
    return Results.Created($"/hotels/{hotel.Id}", hotel);
})
.Accepts<Hotel>("application/json")
.Produces<List<Hotel>>(StatusCodes.Status201Created)
.WithName("CreateHotel")
.WithTags("Creators");//create new hotel 

app.MapPut("/hotels", async ([FromBody] Hotel hotel, IRepository<HotelDb> repository) => {
    await repository.UpdateHotelAsync(hotel);
    await repository.SaveAsync();
    return Results.NoContent();
})
.Accepts<Hotel>("application/json")
.WithName("UpdateHotel")
.WithTags("Updaters");//method for change data from list

app.MapDelete("/hotels/{id}", async (int id, IRepository<HotelDb> repository) => {
    await repository.DeleteHotelAsync(id);
    await repository.SaveAsync();
    return Results.NoContent();
})
.WithName("DeleteHotel")
.WithTags("Deleters");//method for remove data from list

app.MapGet("/hotels/search/name/{query}",
async(string query, IRepository<HotelDb> repository) =>
    await repository.GetHotelAsync(query) is IEnumerable<Hotel> hotels
        ? Results.Ok(hotels)
        : Results.NotFound(Array.Empty<Hotel>()))
        .Produces<List<Hotel>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithName("SearchHotels")
        .WithTags("Getters")
        .ExcludeFromDescription();

app.UseHttpsRedirection();//http to https
app.Run();
