using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;    
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.DataAccess
{    
    public class MongoStatusData
    {    
    
        private readonly IMongoCollection<StatusModel> _statuses;
        private readonly IMemoryCache _cache;
        private const string cacheName = "StatusData";

        public MongoStatusData(IDbConnection db, IMemoryCache cache)
        {
            _cache = cache;
            _statuses = db.StatusCollection;
        }

        public async Task<List<StatusModel>> GetAllStatuses()
        {
            var output = _cache.Get<List<StatusModel>>(cacheName);
            if (output is null) 
            {
                var results = await _statuses.FindAsync(_ => true);

                _cache.Set(cacheName, output, TimeSpan.FromDays(1);
            }
            return output;
        }

        public Task CreateStatus(StatusModel status)
        {
            return _statuses.InsertOneAsync(status);
        }
    }
}
