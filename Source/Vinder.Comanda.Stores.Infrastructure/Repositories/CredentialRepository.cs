namespace Vinder.Comanda.Stores.Infrastructure.Repositories;

public sealed class CredentialRepository(IMongoDatabase database) :
    BaseRepository<Credential>(database, Collections.Credentials),
    ICredentialRepository;
