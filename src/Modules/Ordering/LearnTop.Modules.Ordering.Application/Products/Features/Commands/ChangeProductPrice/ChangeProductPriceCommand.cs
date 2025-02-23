using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Products.Features.Commands.ChangeProductPrice;

public record ChangeProductPriceCommand(
    Guid ProductId,
    long NewPrice)
    : ICommand<ChangeProductPriceResponse>;
