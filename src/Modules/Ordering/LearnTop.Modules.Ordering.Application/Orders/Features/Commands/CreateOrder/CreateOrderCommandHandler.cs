using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Domain.Orders.Enums;
using LearnTop.Modules.Ordering.Domain.Orders.Models;
using LearnTop.Modules.Ordering.Domain.Orders.Repositories;
using LearnTop.Modules.Ordering.Domain.Products.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Orders.Features.Commands.CreateOrder;

internal sealed class CreateOrderCommandHandler(
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateOrderCommand, CreateOrderResponse>
{

    public async Task<Result<CreateOrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.Create(request.CustomerId);
        
        await orderRepository.AddAsync(order);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new CreateOrderResponse(order.Id);
    }
}
