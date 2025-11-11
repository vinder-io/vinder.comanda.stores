namespace Vinder.Comanda.Stores.Application.Handlers.Product;

public sealed class ProductCreationHandler(IProductRepository repository) :
    IMessageHandler<ProductCreationScheme, Result<ProductScheme>>
{
    public async Task<Result<ProductScheme>> HandleAsync(
        ProductCreationScheme message, CancellationToken cancellation = default)
    {
        var product = await repository.InsertAsync(message.AsProduct(), cancellation);
        var response = product.AsResponse();

        return Result<ProductScheme>.Success(response);
    }
}
