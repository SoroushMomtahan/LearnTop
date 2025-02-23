using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Products.Features.Commands.CreateProduct;

public record CreateProductCommand(
    Guid ProductId,
    long Price) : ICommand<CreateProductResponse>;
