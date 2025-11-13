namespace Vinder.Comanda.Stores.Application.Handlers.Establishment;

public sealed class EstablishmentEditionHandler(IEstablishmentRepository repository) :
    IMessageHandler<EstablishmentEditionScheme, Result<EstablishmentScheme>>
{
    public async Task<Result<EstablishmentScheme>> HandleAsync(
        EstablishmentEditionScheme message, CancellationToken cancellation = default)
    {
        var filters = EstablishmentFilters.WithSpecifications()
            .WithIdentifier(message.EstablishmentId)
            .Build();

        var establishments = await repository.GetEstablishmentsAsync(filters, cancellation);
        var existingEstablishment = establishments.FirstOrDefault();

        if (existingEstablishment is null)
        {
            return Result<EstablishmentScheme>.Failure(EstablishmentErrors.EstablishmentDoesNotExist);
        }

        var establishment = await repository.UpdateAsync(existingEstablishment.AsEstablishment(message), cancellation);
        var response = establishment.AsResponse();

        return Result<EstablishmentScheme>.Success(response);
    }
}
