using LearnTop.Modules.Categories.Domain.Categories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Categories.Infrastructure.Categories.Configurations;

public class CategoryRelationConfiguration : IEntityTypeConfiguration<CategoryRelation>
{

    public void Configure(EntityTypeBuilder<CategoryRelation> builder)
    {
        builder.Ignore(x=>x.Id);
        builder.HasKey(x=>new {x.ParentCategoryId, x.ChildCategoryId});
        
        builder
            .HasOne(cr => cr.ParentCategory)
            .WithMany(c => c.ChildCategories)
            .HasForeignKey(cr => cr.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(cr => cr.ChildCategory)
            .WithMany(c => c.ParentCategories)
            .HasForeignKey(cr => cr.ChildCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
