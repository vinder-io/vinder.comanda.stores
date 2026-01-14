namespace Vinder.Comanda.Stores.WebApi.Extensions;

public static class LoggingExtension
{
    public static void AddHttpObservabilityLogging(this IServiceCollection services)
    {
        services.AddHttpLogging(options =>
        {
            options.LoggingFields =
                HttpLoggingFields.RequestMethod |
                HttpLoggingFields.RequestPath |
                HttpLoggingFields.RequestHeaders |
                HttpLoggingFields.RequestBody;

            options.RequestBodyLogLimit = 2 * 1024 * 1024;
            options.ResponseBodyLogLimit = 2 * 1024 * 1024;

            options.RequestHeaders.Add(Headers.Authorization);
            options.RequestHeaders.Add(Headers.Pagination);
        });
    }
}