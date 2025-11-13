namespace Vinder.Comanda.Stores.Application.Payloads.Establishment;

public sealed record EstablishmentDeletionScheme : IMessage<Result>
{
    [property: JsonIgnore]
    public string EstablishmentId { get; init; } = default!;
}
