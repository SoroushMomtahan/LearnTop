using LearnTop.Modules.Ordering.Domain.Coupons.Models;
using LearnTop.Modules.Ordering.Domain.Coupons.Repositories;
using LearnTop.Modules.Ordering.Infrastructure.Data.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Ordering.Infrastructure.Coupons.Repositories;

public class CouponRepository(
    OrderingDbContext orderingDbContext) : ICouponRepository
{

    public async Task<Coupon?> GetCouponAsync(Guid couponId, CancellationToken cancellationToken = default)
    {
        return await orderingDbContext.Coupons
            .FirstOrDefaultAsync(c => c.Id == couponId, cancellationToken);
    }
    public async Task AddAsync(Coupon coupon, CancellationToken cancellationToken = default)
    {
        await orderingDbContext.Coupons.AddAsync(coupon, cancellationToken);
    }
}
