namespace Vinder.Comanda.Stores.Domain.Entities;

public sealed class Establishment : Entity
{
    public Properties Properties { get; set; } = default!;
    public Branding Branding { get; set; } = default!;
    public User Owner { get; set; } = default!;
    public ICollection<IntegrationCredentials> Credentials { get; set; } = [];

    public void WithChanges(Action<EstablishmentBuilder> action) =>
        action(new EstablishmentBuilder(this));
}