namespace Vinder.Comanda.Stores.Application.Handlers.Establishment;

public sealed class EstablishmentCreationHandler(IEstablishmentRepository repository) :
    IMessageHandler<EstablishmentCreationScheme, Result<EstablishmentScheme>>
{
    public async Task<Result<EstablishmentScheme>> HandleAsync(
        EstablishmentCreationScheme message, CancellationToken cancellation = default)
    {
        var filters = EstablishmentFilters.WithSpecifications()
            .WithOwnerId(message.Owner.Identifier)
            .Build();

        var establishments = await repository.GetEstablishmentsAsync(filters, cancellation);
        var existingEstablishment = establishments.FirstOrDefault();

        if (existingEstablishment is not null)
        {
            return Result<EstablishmentScheme>.Failure(EstablishmentErrors.OwnerAlreadyHasEstablishment);
        }

        var establishment = await repository.InsertAsync(message.AsEstablishment(), cancellation);
        var response = establishment.AsResponse();

        return Result<EstablishmentScheme>.Success(response);
    }
}
