namespace Vinder.Comanda.Stores.Application.Mappers;

public static class IntegrationCredentialsMapper
{
    public static IntegrationCredentials AsCredential(this IntegrationCredentialCreationScheme credentials) => new()
    {
        Provider = credentials.Provider,
        SecretKey = credentials.SecretKey,
    };

    public static IntegrationCredentialScheme AsResponse(this IntegrationCredentials credentials) => new()
    {
        Identifier = credentials.Id,
        Provider = credentials.Provider.ToString(),
        SecretKey = credentials.SecretKey,
    };
}
