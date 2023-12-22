using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace AllHostedService
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<CacheService> _logger;

        public CacheService(IDistributedCache cache, ILogger<CacheService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task RefreshDashboardCacheAsync()
        {
            var rng = Random.Shared;
            var dashboardResult = new DashboardResult
            {
                AverageSale = rng.Next(0, 100),
                LastUpdated = DateTime.UtcNow,
                NumberOfSales = rng.Next(0, 10000)
            };
            var encodeDashboard = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(dashboardResult));

            await _cache.SetAsync(CacheKeys.Dashboard, encodeDashboard, new DistributedCacheEntryOption);

            _logger.LogInformation("{cacheKey} cache refreshed", CacheKeys.Dashboard);
        }
    }
}
