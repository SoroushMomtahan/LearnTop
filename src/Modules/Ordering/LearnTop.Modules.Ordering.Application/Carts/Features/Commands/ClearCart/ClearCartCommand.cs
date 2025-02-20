using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Carts.Features.Commands.ClearCart;

public record ClearCartCommand(Guid CustomerId) : ICommand<ClearCartResponse>;
