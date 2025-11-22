namespace Vinder.Comanda.Stores.Domain.Entities;

public sealed class IntegrationCredentials : Entity
{
    public IntegrationTarget Provider { get; set; } = default!;
    public string SecretKey { get; set; } = default!;
}
