using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Domain.Orders.Errors;
using LearnTop.Modules.Ordering.Domain.Orders.Models;
using LearnTop.Modules.Ordering.Domain.Orders.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Orders.Features.Commands.RemoveOrder;

internal sealed class RemoveOrderCommandHandler(
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<RemoveOrderCommand, RemoveOrderResponse>
{

    public async Task<Result<RemoveOrderResponse>> Handle(
        RemoveOrderCommand request, 
        CancellationToken cancellationToken)
    {
        Order? order = await orderRepository.GetAsync(request.OrderId);
        if (order is null)
        {
            return Result.Failure<RemoveOrderResponse>(OrderErrors.NotFound);
        }
        await orderRepository.RemoveAsync(order);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new RemoveOrderResponse();
    }
}
