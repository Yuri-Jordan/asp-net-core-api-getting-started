public class LoggingMiddleware
{
    private readonly ILogger<LoggingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public LoggingMiddleware(ILogger<LoggingMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");
        await _next(context);
    }
}