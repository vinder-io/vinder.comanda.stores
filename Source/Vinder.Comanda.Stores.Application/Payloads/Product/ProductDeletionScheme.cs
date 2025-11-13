namespace Vinder.Comanda.Stores.Application.Payloads.Product;

public sealed record ProductDeletionScheme : IMessage<Result>
{
    [property: JsonIgnore]
    public string EstablishmentId { get; init; } = default!;

    [property: JsonIgnore]
    public string ProductId { get; init; } = default!;
}
