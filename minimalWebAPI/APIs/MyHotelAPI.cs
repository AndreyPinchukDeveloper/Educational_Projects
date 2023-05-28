namespace minimalWebAPI.APIs
{
    //Connected as service in Program.cs
    public class MyHotelAPI:IAPI
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/hotels", Get)
                .Produces<List<Hotel>>(StatusCodes.Status200OK)
                .WithName("GetAllHotels")
                .WithTags("Getters");//GET method

            app.MapGet("/hotels/{id}", GetById)
                .WithName("GetHotel")
                .WithTags("Getters");//gets by id

            app.MapPost("/hotels", Post)
                .Accepts<Hotel>("application/json")
                .Produces<List<Hotel>>(StatusCodes.Status201Created)
                .WithName("CreateHotel")
                .WithTags("Creators");//create new hotel 

            app.MapPut("/hotels", Put)
                .Accepts<Hotel>("application/json")
                .WithName("UpdateHotel")
                .WithTags("Updaters");//method for change data from list

            app.MapDelete("/hotels/{id}", Delete)
                .WithName("DeleteHotel")
                .WithTags("Deleters");//method for remove data from list

            app.MapGet("/hotels/search/name/{query}", SearchByName)
                .Produces<List<Hotel>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("SearchHotels")
                .WithTags("Getters")
                .ExcludeFromDescription();

            app.MapGet("/hotels/search/location/{coordinate}", SearchByCoordinate)
                .ExcludeFromDescription();
        }

        [Authorize]
        private async Task<IResult> Get(IRepository<HotelDb> repository) =>
            Results.Extensions.Xml(await repository.GetHotelAsync());
            
        [Authorize]
        private async Task<IResult> GetById(int id, IRepository<HotelDb> repository) =>
                await repository.GetHotelAsync(id)
                is Hotel hotel
                ? Results.Ok(hotel)
                : Results.NotFound();

        [Authorize]
        private async Task<IResult> Post([FromBody] Hotel hotel, IRepository<HotelDb> repository)
        {
            await repository.InsertHotelAsync(hotel);
            await repository.SaveAsync();
            return Results.Created($"/hotels/{hotel.Id}", hotel);
        }

        [Authorize]
        private async Task<IResult> Put([FromBody] Hotel hotel, IRepository<HotelDb> repository)
        {
                await repository.UpdateHotelAsync(hotel);
                await repository.SaveAsync();
                return Results.NoContent();
        }

        [Authorize]
        private async Task<IResult> Delete(int id, IRepository<HotelDb> repository)
        {
                await repository.DeleteHotelAsync(id);
                await repository.SaveAsync();
                return Results.NoContent();
        }

        [Authorize]
        private async Task<IResult> SearchByName(string query, IRepository<HotelDb> repository) =>
            await repository.GetHotelAsync(query) is IEnumerable<Hotel> hotels
                ? Results.Ok(hotels)
                : Results.NotFound(Array.Empty<Hotel>());

        [Authorize]
        private async Task<IResult> SearchByCoordinate(Coordinate coordinate, IRepository<HotelDb> repository) =>
            await repository.GetHotelAsync(coordinate) is IEnumerable<Hotel> hotels
                ? Results.Ok(hotels)
                : Results.NotFound(Array.Empty<Hotel>());
    }
}
