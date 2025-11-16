namespace Vinder.Comanda.Stores.Application.Handlers.Product;

public sealed class ProductsFetchHandler(IProductRepository repository) :
    IMessageHandler<ProductsFetchParameters, Result<PaginationScheme<ProductScheme>>>
{
    public async Task<Result<PaginationScheme<ProductScheme>>> HandleAsync(
        ProductsFetchParameters parameters, CancellationToken cancellation = default)
    {
        var filters = ProductFilters.WithSpecifications()
            .WithIdentifier(parameters.Id)
            .WithTitle(parameters.Title)
            .WithEstablishmentId(parameters.EstablishmentId)
            .WithMaxPrice(parameters.MaxPrice)
            .WithMinPrice(parameters.MinPrice)
            .WithPagination(parameters.Pagination)
            .WithSort(parameters.Sort)
            .WithCreatedAfter(parameters.CreatedAfter)
            .WithCreatedBefore(parameters.CreatedBefore)
            .Build();

        var products = await repository.GetProductsAsync(filters, cancellation);
        var totalCount = await repository.CountProductsAsync(filters, cancellation);

        var pagination = new PaginationScheme<ProductScheme>
        {
            Items = [.. products.Select(product => product.AsResponse())],
            Total = (int)totalCount,
            PageNumber = parameters.Pagination?.PageNumber ?? 1,
            PageSize = parameters.Pagination?.PageSize ?? 20,
        };

        return Result<PaginationScheme<ProductScheme>>.Success(pagination);
    }
}