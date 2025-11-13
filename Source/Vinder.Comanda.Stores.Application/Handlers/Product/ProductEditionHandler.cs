namespace Vinder.Comanda.Stores.Application.Handlers.Product;

public sealed class ProductEditionHandler(
    IProductRepository productRepository,
    IEstablishmentRepository establishmentRepository
) : IMessageHandler<ProductEditionScheme, Result<ProductScheme>>
{
    public async Task<Result<ProductScheme>> HandleAsync(ProductEditionScheme message, CancellationToken cancellation = default)
    {
        var establishmentFilters = EstablishmentFilters.WithSpecifications()
            .WithIdentifier(message.EstablishmentId)
            .Build();

        var establishments = await establishmentRepository.GetEstablishmentsAsync(establishmentFilters, cancellation);
        var establishment = establishments.FirstOrDefault();

        if (establishment is null)
        {
            return Result<ProductScheme>.Failure(EstablishmentErrors.EstablishmentDoesNotExist);
        }

        var productFilters = ProductFilters.WithSpecifications()
            .WithIdentifier(message.ProductId)
            .Build();

        var products = await productRepository.GetProductsAsync(productFilters, cancellation);
        var product = products.FirstOrDefault();

        if (product is null)
        {
            return Result<ProductScheme>.Failure(ProductErrors.ProductDoesNotExist);
        }

        if (product.Metadata.EstablishmentId != establishment.Id)
        {
            return Result<ProductScheme>.Failure(ProductErrors.ProductBelongsToAnotherEstablishment);
        }

        var updatedProduct = await productRepository.UpdateAsync(message.AsProduct(product), cancellation);
        var response = updatedProduct.AsResponse();

        return Result<ProductScheme>.Success(response);
    }
}
