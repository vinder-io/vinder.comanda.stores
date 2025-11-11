namespace Vinder.Comanda.Stores.Infrastructure.Constants;

public static class Documents
{
    public static class Products
    {
        public const string Identifier = "_id";
        public const string Title = "Properties.Title";
        public const string Price = "Price.Value";
        public const string EstablishmentId = "Metadata.EstablishmentId";
    }

    public static class Establishment
    {
        public const string Identifier = "_id";
        public const string Title = "Properties.Title";
        public const string OwnerId = "Owner.Identifier";
    }
}