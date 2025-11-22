namespace Vinder.Comanda.Stores.Application.Payloads.Establishment;

public sealed record IntegrationCredentialScheme
{
    public string Identifier { get; init; } = default!;
    public string Provider { get; init; } = default!;
    public string SecretKey { get; init; } = default!;
}
