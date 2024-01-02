using Serilog;

namespace TodoApi.Middlewares;

public static class LoggerMiddleware
{
    /// <summary>
    /// Global Logger 설정
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplicationBuilder SetupLogger(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        var logger = new LoggerConfiguration()
            .MinimumLevel.Error()
            .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)
            .Enrich.FromLogContext()
            .CreateLogger();
        builder.Logging.AddSerilog(logger);

        return builder;
    }
}