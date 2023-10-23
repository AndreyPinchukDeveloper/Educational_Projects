namespace WebAPI.Middleware
{
    public class LogUrlMiddleware
    {
        private readonly ILogger<LogUrlMiddleware> _logger;
        private readonly RequestDelegate _next;

        public LogUrlMiddleware(ILogger<LogUrlMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
            throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Request URL: {Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
            await _next(context);
        }
    }
}
