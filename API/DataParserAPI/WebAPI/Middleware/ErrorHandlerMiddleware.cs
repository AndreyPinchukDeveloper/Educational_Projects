using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebAPI.Middleware
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
            WriteIndented = true,
        };

        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, IWebHostEnvironment webHostEnvironment = null)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception) when (context.RequestAborted.IsCancellationRequested)
            {
                const string message = "Request was cancelled";
                _logger.LogInformation(message);
                _logger.LogDebug(exception, message);

                context.Response.Clear();
                context.Response.StatusCode = 499;//client closed request
            }
            catch (Exception exception) 
            {
                exception.AddErrorCode();
                const string message = "An amusing mistake !";
                _logger.LogError(exception, exception is YourAppException ? exception.Message : message);

                const string contentType = "application/json";
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = contentType;

                var json = ToJson(exception);
                await context.Response.WriteAsync(json);

            }
        }

        private string ToJson(in Exception exception)
        {
            var message = exception.Message;
            var code = exception.GetErrorCode();
            if (!_webHostEnvironment.IsDevelopment())
            {
                return JsonSerializer.Serialize(new {message, code}, SerializerOptions);
            }

            try
            {
                var info = exception.ToString();
                var data = exception.Data;
                var error = new { message, code, info, data };
                return JsonSerializer.Serialize(error, SerializerOptions);
            }
            catch (Exception ex)
            {
                const string jsonErrorMessage = "An amusing mistake ! While serializing error to JSON !";
                _logger.LogError(ex, jsonErrorMessage);
            }
            return String.Empty;
        }
    }
}
