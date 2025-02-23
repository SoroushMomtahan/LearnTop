using FluentValidation;

namespace LearnTop.Modules.Ordering.Application.Products.Features.Commands.CreateProduct;

internal sealed class CreateProductValidation : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidation()
    {
        RuleFor(x => x.Price)
            .LessThan(10000000);
    }
}
