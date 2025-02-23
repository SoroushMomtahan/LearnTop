using LearnTop.Modules.Ordering.Domain.Discounts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Ordering.Infrastructure.Discounts.Configurations;

public class ProductDiscountConfiguration : IEntityTypeConfiguration<ProductDiscount>
{

    public void Configure(EntityTypeBuilder<ProductDiscount> builder)
    {
        builder.Ignore(x=>x.Id);
        builder.Ignore(x => x.UpdatedAt);
        builder.HasKey(x => new {
            CourseId = x.ProductId, x.DiscountId });
    }
}
