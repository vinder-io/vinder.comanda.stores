namespace Vinder.Comanda.Stores.Application.Mappers.Establishment;

public static class EstablishmentMapper
{
    public static Domain.Entities.Establishment AsEstablishment(this EstablishmentCreationScheme establishment)
    {
        var branding = new Branding(
            PrimaryColor: string.Empty,
            SecondaryColor: string.Empty,
            Logo: string.Empty
        );

        var properties = new Properties(
            Title: establishment.Title,
            Description: establishment.Description
        );

        return new Domain.Entities.Establishment
        {
            Properties = properties,
            Branding = branding,
            Owner = establishment.Owner
        };
    }

    public static EstablishmentScheme AsResponse(this Domain.Entities.Establishment establishment) => new()
    {
        Identifier = establishment.Id,
        Title = establishment.Properties.Title,
        Description = establishment.Properties.Description,
        Owner = establishment.Owner,
        Branding = establishment.Branding
    };
}
