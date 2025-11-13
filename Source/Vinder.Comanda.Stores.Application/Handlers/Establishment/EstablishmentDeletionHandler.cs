namespace Vinder.Comanda.Stores.Application.Handlers.Establishment;

public sealed class EstablishmentDeletionHandler(IEstablishmentRepository repository) :
    IMessageHandler<EstablishmentDeletionScheme, Result>
{
    public async Task<Result> HandleAsync(
        EstablishmentDeletionScheme message, CancellationToken cancellation = default)
    {
        var filters = EstablishmentFilters.WithSpecifications()
            .WithIdentifier(message.EstablishmentId)
            .Build();

        var establishments = await repository.GetEstablishmentsAsync(filters, cancellation);
        var existingEstablishment = establishments.FirstOrDefault();

        if (existingEstablishment is null)
        {
            /* for tracking purposes: raise error #COMANDA-ERROR-0A2DF */
            return Result.Failure(EstablishmentErrors.EstablishmentDoesNotExist);
        }

        await repository.DeleteAsync(existingEstablishment, cancellation);

        return Result.Success();
    }
}
