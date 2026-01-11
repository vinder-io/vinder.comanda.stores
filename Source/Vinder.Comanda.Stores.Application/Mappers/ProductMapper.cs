namespace Vinder.Comanda.Stores.Application.Mappers;

public static class ProductMapper
{
    public static Domain.Entities.Product AsProduct(this ProductCreationScheme product)
    {
        var properties = new Properties(product.Title, product.Description);
        var metadata = new ProductMetadata(product.EstablishmentId);
        var price = new Price(product.Price);
        var image = new Image(string.Empty);

        return new Domain.Entities.Product
        {
            Properties = properties,
            Price = price,
            Image = image,
            Metadata = metadata
        };
    }

    public static Domain.Entities.Product AsProduct(this ProductEditionScheme patch, Domain.Entities.Product product)
    {
        var properties = new Properties(
            Title: patch.Title,
            Description: patch.Description
        );

        var image = new Image(patch.Image);
        var price = new Price(patch.Price);

        product.Price = price;
        product.Image = image;
        product.Properties = properties;

        return product;
    }

    public static ProductScheme AsResponse(this Domain.Entities.Product product) => new()
    {
        Identifier = product.Id,
        Title = product.Properties.Title,
        Description = product.Properties.Description,
        Image = product.Image?.Path ?? string.Empty,
        Price = product.Price.Value
    };

    public static ProductImageUploadScheme AsImage(this Stream stream, string productId, string establishmentId) => new()
    {
        Stream = stream,
        ProductId = productId,
        EstablishmentId = establishmentId
    };
}
