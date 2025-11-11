namespace Vinder.Comanda.Stores.CrossCutting.Configurations;

public sealed record Settings : ISettings
{
    public DatabaseSettings Database { get; init; } = default!;
    public FederationSettings Federation { get; init; } = default!;
}