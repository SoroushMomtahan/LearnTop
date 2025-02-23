using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Coupons.Models;

public class CouponyCategory
{
    public Guid CategoryId { get; private set; }
    public Guid CouponId { get; private set; }
    
    private CouponyCategory() { }
    public static CouponyCategory Create(Guid categoryId, Guid couponId)
    {
        return new()
        {
            CategoryId = categoryId,
            CouponId = couponId
        };
    }
}
