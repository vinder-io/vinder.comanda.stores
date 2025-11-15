namespace Vinder.Comanda.Stores.Application.Handlers.Product;

public sealed class ProductImageUploadHandler(IProductRepository productRepository, IEstablishmentRepository establishmentRepository, IFileGateway fileGateway) :
    IMessageHandler<ProductImageUploadScheme, Result>
{
    public async Task<Result> HandleAsync(ProductImageUploadScheme parameters, CancellationToken cancellation = default)
    {
        var productFilters = ProductFilters.WithSpecifications()
            .WithIdentifier(parameters.ProductId)
            .WithEstablishmentId(parameters.EstablishmentId)
            .Build();

        var establishmentsFilters = EstablishmentFilters.WithSpecifications()
            .WithIdentifier(parameters.EstablishmentId)
            .Build();

        var establishments = await establishmentRepository.GetEstablishmentsAsync(establishmentsFilters, cancellation);
        var establishment = establishments.FirstOrDefault();

        if (establishment is null)
        {
            return Result.Failure(EstablishmentErrors.EstablishmentDoesNotExist);
        }

        var products = await productRepository.GetProductsAsync(productFilters, cancellation);
        var product = products.FirstOrDefault();

        if (product is null)
        {
            return Result.Failure(ProductErrors.ProductDoesNotExist);
        }

        product.Image = await fileGateway.UploadFileAsync(parameters.Stream, cancellation);

        await productRepository.UpdateAsync(product, cancellation);

        return Result.Success();
    }
}