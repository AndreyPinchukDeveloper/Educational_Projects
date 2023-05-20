var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var hotels = new List<Hotel>();

app.MapGet("/hotels", () => hotels);//GET method
app.MapGet("/hotels/{id}", (int id) => hotels.FirstOrDefault(h=>h.Id ==id));//gets by id
app.MapPost("/hotels", (Hotel hotel) => hotels.Add(hotel));
app.MapPut("/hotels", (Hotel hotel) => {
    var index = hotels.FindIndex(h => h.Id == hotel.Id);
    if(index <0) throw new Exception("Not found");
    hotels[index] = hotel;
});//method for change data from list

app.MapDelete("/hotels/{id}", (int id) => {
    var index = hotels.FindIndex(h => h.Id == id);
    if(index <0) throw new Exception("Not found");
    hotels.RemoveAt(index);
});//method for remove data from list

app.Run();
