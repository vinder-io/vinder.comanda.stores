namespace Vinder.Comanda.Stores.Application.Validators.Product;

public sealed class ProductEditionSchemeValidator : AbstractValidator<ProductEditionScheme>
{
    public ProductEditionSchemeValidator()
    {
        RuleFor(product => product.Title)
            .NotEmpty()
            .WithMessage("product title must be provided.")
            .MaximumLength(100)
            .WithMessage("product title must not exceed 100 characters.");

        RuleFor(product => product.Description)
            .NotEmpty()
            .WithMessage("product description must be provided.")
            .MaximumLength(500)
            .WithMessage("product description must not exceed 500 characters.");

        RuleFor(product => product.Price)
            .GreaterThan(0)
            .WithMessage("product price must be greater than 0.");

        RuleFor(product => product.Image)
            .NotEmpty()
            .WithMessage("product image must be provided.")
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .WithMessage("product image must be a valid URL.");
    }
}
