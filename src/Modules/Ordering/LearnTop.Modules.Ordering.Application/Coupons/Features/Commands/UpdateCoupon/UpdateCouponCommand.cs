using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Coupons.Features.Commands.UpdateCoupon;

public record UpdateCouponCommand(
    Guid CouponId,
    string Code,
    long Ceil,
    long Floor,
    bool IsDeleted,
    DateTime ExpireAt) : ICommand<UpdateCouponResponse>;
