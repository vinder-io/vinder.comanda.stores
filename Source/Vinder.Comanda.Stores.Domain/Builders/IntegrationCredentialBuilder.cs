namespace Vinder.Comanda.Stores.Domain.Builders;

public sealed class IntegrationCredentialBuilder(IntegrationCredentials credential)
{
    private readonly IntegrationCredentials _credential = credential;

    public IntegrationCredentialBuilder SetProvider(IntegrationTarget provider)
    {
        _credential.Provider = provider;
        return this;
    }

    public IntegrationCredentialBuilder SetSecretKey(string secretKey)
    {
        _credential.SecretKey = secretKey;
        return this;
    }

    public IntegrationCredentials Build()
    {
        return _credential;
    }
}
