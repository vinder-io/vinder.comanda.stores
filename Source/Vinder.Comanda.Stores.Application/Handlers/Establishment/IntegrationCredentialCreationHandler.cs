namespace Vinder.Comanda.Stores.Application.Handlers.Establishment;

public sealed class IntegrationCredentialCreationHandler(IIntegrationCredentialsRepository repository, IEstablishmentRepository establishmentRepository) :
    IMessageHandler<IntegrationCredentialCreationScheme, Result<IntegrationCredentialScheme>>
{
    public async Task<Result<IntegrationCredentialScheme>> HandleAsync(
        IntegrationCredentialCreationScheme parameters, CancellationToken cancellation = default)
    {
        var filters = EstablishmentFilters.WithSpecifications()
            .WithIdentifier(parameters.EstablishmentId)
            .Build();

        var establishments = await establishmentRepository.GetEstablishmentsAsync(filters, cancellation);
        var establishment = establishments.FirstOrDefault();

        if (establishment is null)
        {
            return Result<IntegrationCredentialScheme>.Failure(EstablishmentErrors.EstablishmentDoesNotExist);
        }

        var credential = await repository.InsertAsync(parameters.AsCredential(), cancellation);

        establishment.WithChanges(builder =>
        {
            builder.SetCredential(credential);
        });

        await establishmentRepository.UpdateAsync(establishment, cancellation);

        return Result<IntegrationCredentialScheme>.Success(credential.AsResponse());
    }
}
