using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SHOP.DatabaseService.HealthChecks
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            bool isHealthy = await IsDatabaseConnectionOk();
            return isHealthy ? HealthCheckResult.Healthy("Everything ok") 
                : HealthCheckResult.Unhealthy("Something wrong");
        }

        private Task<bool> IsDatabaseConnectionOk()
        {
            return Task.FromResult(true);
        }
    }
}
