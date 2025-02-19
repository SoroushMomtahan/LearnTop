using LearnTop.Modules.Discounts.Domain.Discounts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Discounts.Infrastructure.Discounts.Configurations;

public class CourseDiscountConfiguration : IEntityTypeConfiguration<CourseDiscount>
{

    public void Configure(EntityTypeBuilder<CourseDiscount> builder)
    {
        builder.Ignore(x=>x.Id);
        builder.Ignore(x => x.UpdatedAt);
        builder.HasKey(x => new { x.CourseId, x.DiscountId });
    }
}
