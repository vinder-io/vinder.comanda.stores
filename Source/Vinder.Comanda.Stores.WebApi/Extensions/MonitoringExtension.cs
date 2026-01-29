namespace Vinder.Comanda.Stores.WebApi.Extensions;

[ExcludeFromCodeCoverage(Justification = "contains only http pipeline configuration with no business logic.")]
public static class MonitoringExtension
{
    public static void AddMonitoring(this WebApplicationBuilder builder)
    {
        if (!builder.Environment.IsDevelopment() || !builder.Environment.IsProduction())
            return;

        var settings = builder.Services
            .BuildServiceProvider()
            .GetRequiredService<ISettings>();

        // https://docs.sentry.io/platforms/dotnet/
        builder.WebHost.UseSentry(options =>
        {
            options.Dsn = settings.Observability.SentryDsn;
            options.Environment = builder.Environment.EnvironmentName;
            options.TracesSampleRate = 1.0;
            options.Debug = true;
        });
    }
}