namespace Vinder.Comanda.Stores.Application.Handlers.Product;

public sealed class ProductDeletionHandler(
    IEstablishmentRepository establishmentRepository,
    IProductRepository productRepository
) : IMessageHandler<ProductDeletionScheme, Result>
{
    public async Task<Result> HandleAsync(ProductDeletionScheme message, CancellationToken cancellation = default)
    {
        var establishmentFilters = EstablishmentFilters.WithSpecifications()
            .WithIdentifier(message.EstablishmentId)
            .Build();

        var establishments = await establishmentRepository.GetEstablishmentsAsync(establishmentFilters, cancellation);
        var existingEstablishment = establishments.FirstOrDefault();

        if (existingEstablishment is null)
        {
            /* for tracking purposes: raise error #COMANDA-ERROR-0A2DF */
            return Result.Failure(EstablishmentErrors.EstablishmentDoesNotExist);
        }

        var productFilters = ProductFilters.WithSpecifications()
            .WithIdentifier(message.ProductId)
            .Build();

        var products = await productRepository.GetProductsAsync(productFilters, cancellation);
        var existingProduct = products.FirstOrDefault();

        if (existingProduct is null)
        {
            /* for tracking purposes: raise error #COMANDA-ERROR-C2C1B */
            return Result.Failure(ProductErrors.ProductDoesNotExist);
        }

        if (existingProduct.Metadata.EstablishmentId != existingEstablishment.Id)
        {
            /* for tracking purposes: raise error #COMANDA-ERROR-9FF68 */
            return Result.Failure(ProductErrors.ProductBelongsToAnotherEstablishment);
        }

        await productRepository.DeleteAsync(existingProduct, cancellation);

        return Result.Success();
    }
}
