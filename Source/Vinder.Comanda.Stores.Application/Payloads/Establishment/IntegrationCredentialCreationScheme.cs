namespace Vinder.Comanda.Stores.Application.Payloads.Establishment;

public sealed record IntegrationCredentialCreationScheme :
    IMessage<Result<IntegrationCredentialScheme>>
{
    [property: JsonIgnore]
    public string EstablishmentId { get; set; } = default!;
    public string SecretKey { get; init; } = default!;

    // represents the integration target as a payment gateway or communication channel
    // determines which external service this credential should authenticate against
    public IntegrationTarget Provider { get; init; } = default!;
}
