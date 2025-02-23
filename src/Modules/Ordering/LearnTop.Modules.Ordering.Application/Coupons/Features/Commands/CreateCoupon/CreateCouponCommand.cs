using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Ordering.Application.Coupons.Features.Commands.CreateCoupon;

public record CreateCouponCommand(
    string Code, 
    long Ceil, 
    long Floor, 
    DateTime ExpireAt) : ICommand<CreateCouponResponse>;
