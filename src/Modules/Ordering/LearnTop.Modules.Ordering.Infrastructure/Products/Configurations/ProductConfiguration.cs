using LearnTop.Modules.Ordering.Domain.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Ordering.Infrastructure.Products.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Ignore(x => x.Id);
        builder.HasKey(x => x.ProductId);
    }
}
