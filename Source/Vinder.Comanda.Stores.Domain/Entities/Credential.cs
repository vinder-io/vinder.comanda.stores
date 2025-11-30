namespace Vinder.Comanda.Stores.Domain.Entities;

public sealed class Credential : Entity
{
    public IntegrationTarget Provider { get; set; } = default!;
    public string SecretKey { get; set; } = default!;

    public void WithChanges(Action<CredentialBuilder> action) =>
        action(new CredentialBuilder(this));
}
