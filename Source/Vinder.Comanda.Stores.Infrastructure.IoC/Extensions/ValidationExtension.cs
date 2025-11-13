namespace Vinder.Comanda.Stores.Infrastructure.IoC.Extensions;

[ExcludeFromCodeCoverage(Justification = "contains only dependency injection registration with no business logic.")]
public static class ValidationExtension
{
    public static void AddValidation(this IServiceCollection services)
    {
        services.AddTransient<IValidator<EstablishmentCreationScheme>, EstablishmentCreationSchemeValidator>();
        services.AddTransient<IValidator<EstablishmentEditionScheme>, EstablishmentEditionSchemeValidator>();
        services.AddTransient<IValidator<ProductCreationScheme>, ProductCreationSchemeValidator>();
        services.AddTransient<IValidator<ProductEditionScheme>, ProductEditionSchemeValidator>();
    }
}