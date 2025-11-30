namespace Vinder.Comanda.Stores.Application.Handlers.Establishment;

public sealed class CredentialsFetchHandler(IEstablishmentRepository repository) :
    IMessageHandler<CredentialsFetchParameters, Result<IEnumerable<CredentialScheme>>>
{
    public async Task<Result<IEnumerable<CredentialScheme>>> HandleAsync(
        CredentialsFetchParameters parameters, CancellationToken cancellation = default)
    {
        var filters = EstablishmentFilters.WithSpecifications()
            .WithIdentifier(parameters.EstablishmentId)
            .Build();

        var establishments = await repository.GetEstablishmentsAsync(filters, cancellation);
        var establishment = establishments.FirstOrDefault();

        if (establishment is null)
        {
            return Result<IEnumerable<CredentialScheme>>.Failure(EstablishmentErrors.EstablishmentDoesNotExist);
        }

        return Result<IEnumerable<CredentialScheme>>.Success(
        [
            .. establishment.Credentials.Select(credential => credential.AsResponse())
        ]);
    }
}
