using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Orders.Features.Commands.CreateOrder;

public record CreateOrderCommand(
    Guid CustomerId
    ) : ICommand<CreateOrderResponse>;
