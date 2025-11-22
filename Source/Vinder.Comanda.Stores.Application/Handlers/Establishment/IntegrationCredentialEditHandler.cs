namespace Vinder.Comanda.Stores.Application.Handlers.Establishment;

public sealed class IntegrationCredentialEditHandler(IIntegrationCredentialsRepository repository, IEstablishmentRepository establishmentRepository) :
    IMessageHandler<IntegrationCredentialEditScheme, Result<IntegrationCredentialScheme>>
{
    public async Task<Result<IntegrationCredentialScheme>> HandleAsync(
        IntegrationCredentialEditScheme parameters, CancellationToken cancellation = default)
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

        var existingCredential = establishment.Credentials
            .FirstOrDefault(credential => credential.Id == parameters.CredentialId);

        if (existingCredential is null)
        {
            return Result<IntegrationCredentialScheme>.Failure(CredentialErrors.CredentialDoesNotExist);
        }

        existingCredential.WithChanges(builder =>
        {
            builder.SetProvider(parameters.Provider);
            builder.SetSecretKey(parameters.SecretKey);
        });

        var credential = await repository.UpdateAsync(existingCredential, cancellation);

        return Result<IntegrationCredentialScheme>.Success(credential.AsResponse());
    }
}
