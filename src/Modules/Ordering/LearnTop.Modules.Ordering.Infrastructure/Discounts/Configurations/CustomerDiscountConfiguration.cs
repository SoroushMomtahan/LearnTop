using LearnTop.Modules.Ordering.Domain.Discounts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Ordering.Infrastructure.Discounts.Configurations;

public class CustomerDiscountConfiguration : IEntityTypeConfiguration<CustomerDiscount>
{

    public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
    {
        builder.Ignore(x=>x.Id);
        builder.Ignore(x => x.UpdatedAt);
        builder.HasKey(x=>new {x.DiscountId,
            UserId = x.CustomerId});
    }
}
