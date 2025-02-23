using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Domain.Coupons.Models;
using LearnTop.Modules.Ordering.Domain.Coupons.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Application.Coupons.Features.Commands.CreateCoupon;

internal sealed class CreateCouponCommandHandler(
    ICouponRepository couponRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCouponCommand, CreateCouponResponse>
{

    public async Task<Result<CreateCouponResponse>> Handle(
        CreateCouponCommand request, 
        CancellationToken cancellationToken)
    {
        Result<Coupon> result = Coupon.Create(
            request.Code,
            request.Ceil,
            request.Floor,
            request.ExpireAt);
        if (result.IsFailure)
        {
            return Result.Failure<CreateCouponResponse>(result.Error);
        }
        
        await couponRepository.AddAsync(result.Value, cancellationToken);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateCouponResponse(result.Value.Id);
    }
}
