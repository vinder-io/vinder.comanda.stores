namespace Vinder.Comanda.Stores.Application.Payloads.Product;

public sealed record ProductsFetchParameters :
    IMessage<Result<PaginationScheme<ProductScheme>>>
{
    public string? Id { get; set; }
    public string? EstablishmentId { get; set; }
    public string? Title { get; set; }

    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }

    public PaginationFilters? Pagination { get; set; }
    public SortFilters? Sort { get; set; }

    public DateOnly? CreatedAfter { get; set; }
    public DateOnly? CreatedBefore { get; set; }
}
