using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Domain.Orders.Errors;
using LearnTop.Modules.Ordering.Domain.Orders.Models;
using LearnTop.Modules.Ordering.Domain.Orders.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Orders.Features.Commands.ChangeOrderStatus;

internal sealed class ChangeOrderStatusCommandHandler(
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<ChangeOrderStatusCommand, ChangeOrderStatusResponse>
{

    public async Task<Result<ChangeOrderStatusResponse>> Handle(
        ChangeOrderStatusCommand request, 
        CancellationToken cancellationToken)
    {
        Order? order = await orderRepository.GetAsync(request.OrderId);
        if (order is null)
        {
            return Result.Failure<ChangeOrderStatusResponse>(OrderErrors.NotFound);
        }
        order.ChangeOrderStatus(request.OrderStatus);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new ChangeOrderStatusResponse();
    }
}
