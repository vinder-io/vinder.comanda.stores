namespace Vinder.Comanda.Stores.Application.Payloads.Establishment;

public sealed record IntegrationCredentialsFetchParameters :
    IMessage<Result<IEnumerable<IntegrationCredentialScheme>>>
{
    public string EstablishmentId { get; init; } = default!;
}
