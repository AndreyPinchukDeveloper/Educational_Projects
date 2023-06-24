namespace MainLibrary.DataAccess 
{
    public class MongoSuggestionData
    {
        private readonly IDbConnection _db;
        private readonly IUserData _userData;
        private readonly  IMemoryCache _cache;

        public MongoSuggestionData(IDbConnection db, IUserData userData, IMemoryCache cach)
        {
            _db = db;
            _userData = userData;
            _cache = cache;
        }

    }
}