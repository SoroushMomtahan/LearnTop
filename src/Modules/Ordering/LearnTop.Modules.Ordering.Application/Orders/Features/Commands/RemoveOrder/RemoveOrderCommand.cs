using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Orders.Features.Commands.RemoveOrder;

public record RemoveOrderCommand(Guid OrderId) : ICommand<RemoveOrderResponse>;
