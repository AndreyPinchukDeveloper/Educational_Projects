interface IRepository<T>: IDisposable where T:class
{
    Task<List<Hotel>> GetHotelAsync();
    Task<List<Hotel>> GetHotelAsync(string name);
    Task<Hotel> GetHotelAsync(int hotelId);
    Task<List<Hotel>> GetHotelAsync(Coordinate coordinate);
    Task InsertHotelAsync(Hotel hotel);
    Task UpdateHotelAsync(Hotel hotel);
    Task DeleteHotelAsync(int hotelId);
    Task SaveAsync();
}