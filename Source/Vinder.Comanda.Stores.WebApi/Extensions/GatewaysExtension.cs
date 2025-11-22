namespace Vinder.Comanda.Stores.WebApi.Extensions;

public static class GatewaysExtension
{
    public static void AddGateways(this IServiceCollection services, IWebHostEnvironment environment)
    {
        services.AddSingleton<IFileGateway, FileGateway>(provider =>
        {
            return new FileGateway(Path.Combine(environment.WebRootPath, "Uploads"));
        });
    }
}