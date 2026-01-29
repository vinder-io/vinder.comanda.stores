namespace Vinder.Comanda.Stores.WebApi.Extensions;

[ExcludeFromCodeCoverage(Justification = "contains only http pipeline configuration with no business logic.")]
public static class ObservabilityExtension
{
    public static void AddObservability(this WebApplicationBuilder builder)
    {
        if (!builder.Environment.IsDevelopment() || !builder.Environment.IsProduction())
            return;

        builder.Host.UseSerilog((context, services, logger) =>
        {
            var settings = services.GetRequiredService<ISettings>();

            logger
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Seq(settings.Observability.SeqServerUrl);
        });
    }
}