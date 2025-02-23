using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Domain.Coupons.Errors;
using LearnTop.Modules.Ordering.Domain.Coupons.Models;
using LearnTop.Modules.Ordering.Domain.Coupons.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Coupons.Features.Commands.ChangeCouponIsDeletedStatus;

internal sealed class ChangeCouponIsDeletedStatusCommandHandler(
    ICouponRepository couponRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<ChangeCouponIsDeletedStatusCommand, ChangeCouponIsDeletedStatusResponse>
{

    public async Task<Result<ChangeCouponIsDeletedStatusResponse>> Handle(
        ChangeCouponIsDeletedStatusCommand request, 
        CancellationToken cancellationToken)
    {
        Coupon? coupon = await couponRepository.GetCouponAsync(request.CouponId, cancellationToken);
        if (coupon is null)
        {
            return Result.Failure<ChangeCouponIsDeletedStatusResponse>(CouponErrors.NotFound);
        }
        
        coupon.ChangeDeleteStatus(request.IsDeleted);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new ChangeCouponIsDeletedStatusResponse();
    }
}
