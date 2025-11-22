namespace Vinder.Comanda.Stores.Infrastructure.Repositories;

public sealed class IntegrationCredentialsRepository(IMongoDatabase database) :
    BaseRepository<IntegrationCredentials>(database, Collections.Credentials),
    IIntegrationCredentialsRepository;
