using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace AllHostedService.Dashboard
{
    public class DashboardController:ControllerBase
    {
        //private readonly 

        /*[HttpGet]
        public async Task<DashboardResult?> Get()
        {
            var encodeDashboard = await _cache.GetAsync(CacheKeys.Dashboard);
            var dashboard = JsonSerializer.Deserialize<DashboardResult>(Encoding.UTF8.GetString(encodeDashboard));
            return dashboard;
        }*/
    }
}
