using LearnTop.Modules.Ordering.Domain.Orders.Enums;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Orders.Features.Commands.ChangeOrderStatus;

public record ChangeOrderStatusCommand(
    Guid OrderId,
    OrderStatus OrderStatus) : ICommand<ChangeOrderStatusResponse>;
