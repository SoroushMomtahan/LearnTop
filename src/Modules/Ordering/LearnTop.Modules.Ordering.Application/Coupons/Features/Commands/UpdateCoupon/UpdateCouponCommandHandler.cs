using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Domain.Coupons.Errors;
using LearnTop.Modules.Ordering.Domain.Coupons.Models;
using LearnTop.Modules.Ordering.Domain.Coupons.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Coupons.Features.Commands.UpdateCoupon;

internal sealed class UpdateCouponCommandHandler(
    ICouponRepository repository, 
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateCouponCommand, UpdateCouponResponse>
{

    public async Task<Result<UpdateCouponResponse>> Handle(
        UpdateCouponCommand request, 
        CancellationToken cancellationToken)
    {
        Coupon? coupon = await repository.GetCouponAsync(request.CouponId, cancellationToken);
        if (coupon is null)
        {
            return Result.Failure<UpdateCouponResponse>(CouponErrors.NotFound);
        }

        Result result = coupon.Update(
            request.Code,
            request.Ceil,
            request.Floor,
            request.ExpireAt);
        if (result.IsFailure)
        {
            return Result.Failure<UpdateCouponResponse>(result.Error);
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new UpdateCouponResponse();
    }
}
