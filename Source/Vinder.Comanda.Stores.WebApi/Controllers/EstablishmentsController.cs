namespace Vinder.Comanda.Stores.WebApi.Controllers;

[ApiController]
[Route("api/v1/establishments")]
public sealed class EstablishmentsController(IDispatcher dispatcher) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEstablishmentAsync(
        [FromBody] EstablishmentCreationScheme request, CancellationToken cancellation)
    {
        var result = await dispatcher.DispatchAsync(request, cancellation);

        return result switch
        {
            { IsSuccess: true } =>
                StatusCode(StatusCodes.Status200OK, result.Data),

            /* for tracking purposes: raise error #COMANDA-ERROR-84F47 */
            { IsFailure: true } when result.Error == EstablishmentErrors.OwnerAlreadyHasEstablishment =>
                StatusCode(StatusCodes.Status409Conflict, result.Error)
        };
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEstablishmentAsync(
        [FromBody] EstablishmentEditionScheme request, [FromRoute] string id, CancellationToken cancellation)
    {
        var result = await dispatcher.DispatchAsync(request with { EstablishmentId = id }, cancellation);

        return result switch
        {
            { IsSuccess: true } =>
                StatusCode(StatusCodes.Status200OK, result.Data),

            /* for tracking purposes: raise error #COMANDA-ERROR-0A2DF */
            { IsFailure: true } when result.Error == EstablishmentErrors.EstablishmentDoesNotExist =>
                StatusCode(StatusCodes.Status404NotFound, result.Error)
        };
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEstablishmentAsync(
        [FromQuery] EstablishmentDeletionScheme request, [FromRoute] string id, CancellationToken cancellation)
    {
        var result = await dispatcher.DispatchAsync(request with { EstablishmentId = id }, cancellation);

        return result switch
        {
            { IsSuccess: true } => StatusCode(StatusCodes.Status204NoContent),

            /* for tracking purposes: raise error #COMANDA-ERROR-0A2DF */
            { IsFailure: true } when result.Error == EstablishmentErrors.EstablishmentDoesNotExist =>
                StatusCode(StatusCodes.Status404NotFound, result.Error)
        };
    }

    [HttpPost("{id}/products")]
    public async Task<IActionResult> CreateProductAsync(
        [FromBody] ProductCreationScheme request, [FromRoute] string id, CancellationToken cancellation)
    {
        var result = await dispatcher.DispatchAsync(request with { EstablishmentId = id }, cancellation);

        // we know the switch here is not strictly necessary since we only handle the success case,
        // but we keep it for consistency with the rest of the codebase and to follow established patterns.
        return result switch
        {
            { IsSuccess: true } => StatusCode(StatusCodes.Status201Created, result.Data),
        };
    }

    [HttpPut("{id}/products/{productId}")]
    public async Task<IActionResult> UpdateProductAsync(
        [FromBody] ProductEditionScheme request, [FromRoute] string id, [FromRoute] string productId, CancellationToken cancellation)
    {
        var result = await dispatcher.DispatchAsync(request with { EstablishmentId = id, ProductId = productId }, cancellation);

        // we know the switch here is not strictly necessary since we only handle the success case,
        // but we keep it for consistency with the rest of the codebase and to follow established patterns.
        return result switch
        {
            { IsSuccess: true } =>
                StatusCode(StatusCodes.Status200OK, result.Data),

            /* for tracking purposes: raise error #COMANDA-ERROR-0A2DF */
            { IsFailure: true } when result.Error == EstablishmentErrors.EstablishmentDoesNotExist =>
                StatusCode(StatusCodes.Status404NotFound, result.Error),

            /* for tracking purposes: raise error #COMANDA-ERROR-C2C1B */
            { IsFailure: true } when result.Error == ProductErrors.ProductDoesNotExist =>
                StatusCode(StatusCodes.Status404NotFound, result.Error),

            /* for tracking purposes: raise error #COMANDA-ERROR-9FF68 */
            { IsFailure: true } when result.Error == ProductErrors.ProductBelongsToAnotherEstablishment =>
                StatusCode(StatusCodes.Status422UnprocessableEntity, result.Error)
        };
    }
}
