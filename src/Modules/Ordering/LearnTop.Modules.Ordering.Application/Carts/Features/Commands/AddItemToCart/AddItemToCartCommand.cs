using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Carts.Features.Commands.AddItemToCart;

public record AddItemToCartCommand(Guid CourseId, Guid CustomerId)
    : ICommand<AddItemToCartResponse>;
