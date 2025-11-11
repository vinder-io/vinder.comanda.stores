namespace Vinder.Comanda.Stores.Infrastructure.Pipelines;

public static class ProductPipelineDefinition
{
    public static PipelineDefinition<Product, BsonDocument> FilterProducts(
        this PipelineDefinition<Product, BsonDocument> pipeline,
        ProductFilters filters)
    {
        var definitions = new List<FilterDefinition<BsonDocument>>
        {
            FilterDefinitions.MatchIfNotEmpty(Documents.Products.Identifier, filters.Id),
            FilterDefinitions.MatchIfNotEmpty(Documents.Products.EstablishmentId, filters.EstablishmentId),

            FilterDefinitions.MatchIfContains(Documents.Products.Title, filters.Title),
            FilterDefinitions.MustBeWithinIfNotNull(Documents.Products.Price, filters.MinPrice, filters.MaxPrice)
        };

        return pipeline.Match(Builders<BsonDocument>.Filter.And(definitions));
    }
}