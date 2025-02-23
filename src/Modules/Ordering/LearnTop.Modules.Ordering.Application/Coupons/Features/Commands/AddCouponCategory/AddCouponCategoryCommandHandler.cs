using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Domain.Coupons.Errors;
using LearnTop.Modules.Ordering.Domain.Coupons.Models;
using LearnTop.Modules.Ordering.Domain.Coupons.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Coupons.Features.Commands.AddCouponCategory;

internal sealed class AddCouponCategoryCommandHandler(
    ICouponRepository couponRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddCouponCategoryCommand, AddCouponCategoryResponse>
{

    public async Task<Result<AddCouponCategoryResponse>> Handle(
        AddCouponCategoryCommand request, 
        CancellationToken cancellationToken)
    {
        // TODO: Found Category
        Coupon? coupon = await couponRepository.GetCouponAsync(request.CouponId, cancellationToken);
        if (coupon is null)
        {
            return Result.Failure<AddCouponCategoryResponse>(CouponErrors.NotFound);
        }

        coupon.AddCategory(request.CategoryId);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new AddCouponCategoryResponse();
    }
}
