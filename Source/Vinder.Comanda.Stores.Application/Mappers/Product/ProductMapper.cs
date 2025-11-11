namespace Vinder.Comanda.Stores.Application.Mappers.Product;

public static class ProductMapper
{
    public static Domain.Entities.Product AsProduct(this ProductCreationScheme product)
    {
        var properties = new Properties(product.Title, product.Description);
        var metadata = new ProductMetadata(product.EstablishmentId);

        var image = new Image(product.ImagePath);
        var price = new Price(product.Price);

        return new Domain.Entities.Product
        {
            Properties = properties,
            Image = image,
            Price = price,
            Metadata = metadata
        };
    }

    public static ProductScheme AsResponse(this Domain.Entities.Product product) => new()
    {
        Identifier = product.Id,
        Title = product.Properties.Title,
        Description = product.Properties.Description,
        Image = product.Image.Path,
        Price = product.Price.Value
    };
}
