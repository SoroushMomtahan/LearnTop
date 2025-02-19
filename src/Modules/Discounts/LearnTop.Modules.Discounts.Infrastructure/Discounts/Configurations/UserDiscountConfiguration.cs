using LearnTop.Modules.Discounts.Domain.Discounts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Discounts.Infrastructure.Discounts.Configurations;

public class UserDiscountConfiguration : IEntityTypeConfiguration<UserDiscount>
{

    public void Configure(EntityTypeBuilder<UserDiscount> builder)
    {
        builder.Ignore(x=>x.Id);
        builder.Ignore(x => x.UpdatedAt);
        builder.HasKey(x=>new {x.DiscountId, x.UserId});
    }
}
