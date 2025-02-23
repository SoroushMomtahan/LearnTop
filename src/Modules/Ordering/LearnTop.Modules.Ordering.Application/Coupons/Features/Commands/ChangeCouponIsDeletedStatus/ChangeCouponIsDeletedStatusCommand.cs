using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Coupons.Features.Commands.ChangeCouponIsDeletedStatus;

public record ChangeCouponIsDeletedStatusCommand(
    Guid CouponId,
    bool IsDeleted) : ICommand<ChangeCouponIsDeletedStatusResponse>;
