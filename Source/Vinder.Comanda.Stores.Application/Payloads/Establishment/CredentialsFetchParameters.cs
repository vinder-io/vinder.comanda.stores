namespace Vinder.Comanda.Stores.Application.Payloads.Establishment;

public sealed record CredentialsFetchParameters :
    IMessage<Result<IEnumerable<CredentialScheme>>>
{
    public string EstablishmentId { get; init; } = default!;
}
