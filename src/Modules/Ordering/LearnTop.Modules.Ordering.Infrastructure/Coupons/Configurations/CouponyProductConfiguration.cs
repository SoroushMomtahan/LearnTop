using LearnTop.Modules.Ordering.Domain.Coupons.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Ordering.Infrastructure.Coupons.Configurations;

internal sealed class CouponyProductConfiguration : IEntityTypeConfiguration<CouponyProduct>
{

    public void Configure(EntityTypeBuilder<CouponyProduct> builder)
    {
        builder.HasKey(x=>new {x.CouponId, x.ProductId});
    }
}
