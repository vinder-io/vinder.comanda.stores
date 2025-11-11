namespace Vinder.Comanda.Stores.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    public Task<IReadOnlyCollection<Product>> GetProductsAsync(
        ProductFilters filters,
        CancellationToken cancellation = default
    );

    public Task<long> CountProductsAsync(
        ProductFilters filters,
        CancellationToken cancellation = default
    );
}