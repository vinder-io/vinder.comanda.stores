namespace Vinder.Comanda.Stores.Application.Handlers.Establishment;

public sealed class IntegrationCredentialsFetchHandler(IEstablishmentRepository repository) :
    IMessageHandler<IntegrationCredentialsFetchParameters, Result<IEnumerable<IntegrationCredentialScheme>>>
{
    public async Task<Result<IEnumerable<IntegrationCredentialScheme>>> HandleAsync(
        IntegrationCredentialsFetchParameters parameters, CancellationToken cancellation = default)
    {
        var filters = EstablishmentFilters.WithSpecifications()
            .WithIdentifier(parameters.EstablishmentId)
            .Build();

        var establishments = await repository.GetEstablishmentsAsync(filters, cancellation);
        var establishment = establishments.FirstOrDefault();

        if (establishment is null)
        {
            return Result<IEnumerable<IntegrationCredentialScheme>>.Failure(EstablishmentErrors.EstablishmentDoesNotExist);
        }

        return Result<IEnumerable<IntegrationCredentialScheme>>.Success(
        [
            .. establishment.Credentials.Select(credential => credential.AsResponse())
        ]);
    }
}
