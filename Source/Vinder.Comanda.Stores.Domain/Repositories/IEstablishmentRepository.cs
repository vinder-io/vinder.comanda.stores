namespace Vinder.Comanda.Stores.Domain.Repositories;

public interface IEstablishmentRepository : IBaseRepository<Establishment>
{
    public Task<IReadOnlyCollection<Establishment>> GetEstablishmentsAsync(
        EstablishmentFilters filters,
        CancellationToken cancellation = default
    );

    public Task<long> CountEstablishmentsAsync(
        EstablishmentFilters filters,
        CancellationToken cancellation = default
    );
}