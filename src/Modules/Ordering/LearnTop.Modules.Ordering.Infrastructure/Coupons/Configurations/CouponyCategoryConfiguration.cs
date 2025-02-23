using LearnTop.Modules.Ordering.Domain.Coupons.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Ordering.Infrastructure.Coupons.Configurations;

internal sealed class CouponyCategoryConfiguration : IEntityTypeConfiguration<CouponyCategory>
{

    public void Configure(EntityTypeBuilder<CouponyCategory> builder)
    {
        builder.HasKey(x=>new { x.CategoryId, x.CouponId });
    }
}
