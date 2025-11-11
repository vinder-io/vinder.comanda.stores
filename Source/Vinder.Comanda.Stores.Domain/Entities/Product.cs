namespace Vinder.Comanda.Stores.Domain.Entities;

public sealed class Product : Entity
{
    public Image Image { get; set; } = default!;
    public Price Price { get; set; } = default!;
    public Properties Properties { get; set; } = default!;
    public ProductMetadata Metadata { get; set; } = default!;
}
