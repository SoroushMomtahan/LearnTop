using LearnTop.Modules.Ordering.Domain.Coupons.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Ordering.Infrastructure.Coupons.Configurations;

internal sealed class CouponyUserConfiguration : IEntityTypeConfiguration<CouponyUser>
{

    public void Configure(EntityTypeBuilder<CouponyUser> builder)
    {
        builder.HasKey(x => new { x.CouponId, x.UserId });
    }
}
