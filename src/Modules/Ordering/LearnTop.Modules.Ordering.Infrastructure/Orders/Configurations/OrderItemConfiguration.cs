using LearnTop.Modules.Ordering.Domain.Orders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Ordering.Infrastructure.Orders.Configurations;

internal sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{

    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Ignore(x=>x.Id);
        builder.HasKey(x=>new {x.CourseId, x.OrderId});
    }
}
