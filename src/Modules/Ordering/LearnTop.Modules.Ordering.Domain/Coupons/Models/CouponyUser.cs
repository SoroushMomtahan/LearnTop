using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Coupons.Models;

public class CouponyUser
{
    public Guid UserId { get; private set; }
    public Guid CouponId { get; private set; }
    
    private CouponyUser(){}
    public static CouponyUser Create(Guid userId, Guid couponId)
    {
        return new()
        {
            UserId = userId,
            CouponId = couponId
        };
    }
}
