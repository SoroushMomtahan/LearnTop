using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Domain.Discounts.Models;
using LearnTop.Modules.Ordering.Domain.Discounts.Repositories;
using LearnTop.Modules.Ordering.Domain.Orders.Errors;
using LearnTop.Modules.Ordering.Domain.Orders.Models;
using LearnTop.Modules.Ordering.Domain.Orders.Repositories;
using LearnTop.Modules.Ordering.Domain.Products.Errors;
using LearnTop.Modules.Ordering.Domain.Products.Models;
using LearnTop.Modules.Ordering.Domain.Products.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Orders.Features.Commands.AddOrderItem;

internal sealed class AddOrderItemCommandHandler(
    IOrderRepository orderRepository,
    IProductRepository productRepository,
    IDiscountRepository discountRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddOrderItemCommand, AddOrderItemResponse>
{

    public async Task<Result<AddOrderItemResponse>> Handle(
        AddOrderItemCommand request, 
        CancellationToken cancellationToken)
    {
        Order? order = await orderRepository.GetAsync(request.OrderId);
        if (order is null)
        {
            return Result.Failure<AddOrderItemResponse>(OrderErrors.NotFound);
        }

        Product? product = await productRepository.GetAsync(request.ProductId);
        if (product is null)
        {
            return Result.Failure<AddOrderItemResponse>(ProductErrors.NotFound);
        }

        List<Discount> customerDiscountsForAddedProduct = await discountRepository
            .GetAsync(
                request.ProductId, 
                order.CustomerId,
                cancellationToken);
        
        int maxDiscount = customerDiscountsForAddedProduct.Max(x => x.Percent);
        
        order.AddOrderItem(request.ProductId, product.Price, maxDiscount);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AddOrderItemResponse();
    }
}
