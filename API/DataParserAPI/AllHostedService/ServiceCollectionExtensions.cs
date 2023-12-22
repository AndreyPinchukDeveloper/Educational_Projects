namespace AllHostedService
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDemoServices(this ServiceCollection services) 
        {
            services.AddSingleton<ICacheService, CacheService>();
            services.AddLogging(loggerConfig =>
                {
                    loggerConfig.AddSimpleConsole(options => options.TimestampFormat = "[HH:mm:ss]");
                });
                
        }
    }
}
