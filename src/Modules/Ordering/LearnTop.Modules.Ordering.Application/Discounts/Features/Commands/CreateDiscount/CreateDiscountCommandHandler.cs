using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Domain.Discounts.Models;
using LearnTop.Modules.Ordering.Domain.Discounts.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Discounts.Features.Commands.CreateDiscount;

internal sealed class CreateDiscountCommandHandler(
    IDiscountRepository discountRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateDiscountCommand, CreateDiscountResponse>
{

    public async Task<Result<CreateDiscountResponse>> Handle(
        CreateDiscountCommand request, 
        CancellationToken cancellationToken)
    {
        Result<Discount> createDiscountResult = Discount.Create(
            request.Percent, request.StartAt, request.EndAt);

        if (createDiscountResult.IsFailure)
        {
            return Result.Failure<CreateDiscountResponse>(createDiscountResult.Error);
        }
        
        Discount discount = createDiscountResult.Value;
        
        discount.AddProductDiscounts(request.CourseIds);
        
        discount.AddCustomerDiscounts(request.UserIds);
        
        await discountRepository.AddAsync(discount, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateDiscountResponse(discount.Id);
    }
}
