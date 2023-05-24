public class SQLHotelRepository : IRepository<HotelDb>
{
    private readonly HotelDb _context;
    public SQLHotelRepository(HotelDb context)
    {
        _context = context;
    }
    public Task<List<Hotel>> GetHotelAsync()=> 
        _context.Hotels.ToListAsync();

    public async Task<List<Hotel>> GetHotelAsync(string name) => 
        await _context.Hotels.Where(h=>h.Name.Contains(name)).ToListAsync();

    public async Task<Hotel> GetHotelAsync(int hotelId) =>
        await _context.Hotels.FindAsync(new object[]{hotelId});

    public async Task<List<Hotel>> GetHotelAsync(Coordinate coordinate) =>
        await _context.Hotels.Where(hotel =>
            hotel.Latitude > coordinate.Latitude -1 &&
            hotel.Latitude < coordinate.Latitude +1 &&
            hotel.Longtitude > coordinate.Longtitude -1 &&
            hotel.Longtitude < coordinate.Longtitude +1 
        ).ToListAsync();

    public async Task InsertHotelAsync(Hotel hotel) =>
        await _context.Hotels.AddAsync(hotel);

    public async Task UpdateHotelAsync(Hotel hotel)
    {
        var hotelFromDb = await _context.Hotels.FindAsync(new object[]{hotel.Id});
        if(hotelFromDb==null) return;
        hotelFromDb.Longtitude = hotel.Longtitude;
        hotelFromDb.Latitude = hotel.Latitude;
        hotelFromDb.Name = hotel.Name;
    }
    
    public async Task DeleteHotelAsync(int hotelId) 
    {
        var hotelFromDb = await _context.Hotels.FindAsync(new object[]{hotelId});
        if(hotelFromDb==null) return;
        _context.Hotels.Remove(hotelFromDb);
    }
        
    public Task SaveAsync() => _context.SaveChangesAsync();

    private bool _disposed = false;

    protected virtual void Dispose(bool isDisposing)
    {
        if(!_disposed)
        {
            if(isDisposing) _context.Dispose();
        }
        _disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    //~SQLHotelRepository() => Dispose(false);// the finalizer
}