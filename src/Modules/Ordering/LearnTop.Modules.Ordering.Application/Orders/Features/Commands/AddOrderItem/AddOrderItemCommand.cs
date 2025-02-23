using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Orders.Features.Commands.AddOrderItem;

public record AddOrderItemCommand(
    Guid OrderId,
    Guid ProductId) : ICommand<AddOrderItemResponse>;
