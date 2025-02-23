using LearnTop.Modules.Ordering.Domain.Coupons.Models;

namespace LearnTop.Modules.Ordering.Domain.Coupons.Repositories;

public interface ICouponRepository
{
    Task<Coupon?> GetCouponAsync(Guid couponId, CancellationToken cancellationToken = default);
    Task AddAsync(Coupon coupon, CancellationToken cancellationToken = default);
}
