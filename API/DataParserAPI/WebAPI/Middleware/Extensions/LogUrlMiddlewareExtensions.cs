namespace WebAPI.Middleware.Extensions
{
    public static class LogUrlMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogUrlMiddleware>();
        }
    }
}
