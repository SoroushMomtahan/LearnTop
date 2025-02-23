using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Ordering.Domain.Coupons.Models;

public class CouponyProduct
{
    public Guid ProductId { get; private set; }
    public Guid CouponId { get; private set; }
    
    private CouponyProduct(){}
    public static CouponyProduct Create(Guid productId, Guid couponId)
    {
        return new()
        {
            ProductId = productId,
            CouponId = couponId
        };
    }
}
