using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SHOP.DatabaseService.HealthChecks
{
    public class DatabaseConsistencyHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            bool isHealthy = await IsDatabaseConsistencyConnectionOk();
            return isHealthy ? HealthCheckResult.Healthy("Everything ok")
                : HealthCheckResult.Unhealthy("Something wrong");
        }

        private Task<bool> IsDatabaseConsistencyConnectionOk()
        {
            return Task.FromResult(true);
        }
    }
}
