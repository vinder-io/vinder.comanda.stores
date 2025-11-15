namespace Vinder.Comanda.Stores.Application.Payloads.Product;

public sealed record ProductImageUploadScheme : IMessage<Result>
{
    public string ProductId { get; init; } = default!;
    public string EstablishmentId { get; init; } = default!;
    public Stream Stream { get; init; } = default!;
}