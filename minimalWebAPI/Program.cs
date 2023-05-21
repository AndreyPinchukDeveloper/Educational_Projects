var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HotelDb>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<HotelDb>();
    db.Database.EnsureCreated();
}

app.MapGet("/hotels", async (HotelDb db) => await db.Hotels.ToListAsync());//GET method
app.MapGet("/hotels/{id}", async (int id, HotelDb db) => 
    await db.Hotels.FirstOrDefaultAsync(h=>h.Id ==id)
    is Hotel hotel 
    ? Results.Ok(hotel)
    : Results.NotFound());//gets by id

app.MapPost("/hotels", async ([FromBody] Hotel hotel, HotelDb db) => 
{
    db.Hotels.Add(hotel);
    await db.SaveChangesAsync();
    return Results.Created($"/hotels/{hotel.Id}", hotel);
});

app.MapPut("/hotels", async ([FromBody] Hotel hotel, HotelDb db) => {
    var hotelFromDb = await db.Hotels.FindAsync(new object[] {hotel.Id});
    if(hotelFromDb == null) return Results.NotFound();
    hotelFromDb.Latitude = hotel.Latitude;
    hotelFromDb.Longtitude = hotel.Longtitude;
    await db.SaveChangesAsync();
    return Results.NoContent();
});//method for change data from list

app.MapDelete("/hotels/{id}", async (int id, HotelDb db) => {
    var hotelFromDbToDelete = await db.Hotels.FindAsync(new object[] {id});
    if(hotelFromDbToDelete==null) return Results.NotFound();
    db.Hotels.Remove(hotelFromDbToDelete);
    await db.SaveChangesAsync();
    return Results.NoContent();
});//method for remove data from list

app.UseHttpsRedirection();//http to https
app.Run();
