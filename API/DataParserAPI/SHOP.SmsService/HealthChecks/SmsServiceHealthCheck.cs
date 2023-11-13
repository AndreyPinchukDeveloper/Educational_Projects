using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SHOP.SmsService.HealthChecks
{
    public class SmsServiceHealthCheck:IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            bool isHealthy = await IsSmsServiceOk();
            return isHealthy ? HealthCheckResult.Healthy("Everything ok")
                : HealthCheckResult.Unhealthy("Something wrong");
        }

        private Task<bool> IsSmsServiceOk()
        {
            return Task.FromResult(true);
        }
    }
}
