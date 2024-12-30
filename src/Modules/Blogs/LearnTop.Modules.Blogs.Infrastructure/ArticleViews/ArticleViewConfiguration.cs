using LearnTop.Modules.Blogs.Domain.Articles.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Blogs.Infrastructure.ArticleViews;

public class ArticleViewConfiguration : IEntityTypeConfiguration<ArticleView>
{

    public void Configure(EntityTypeBuilder<ArticleView> builder)
    {
        builder.HasMany(av => av.TagViews)
            .WithOne()
            .HasForeignKey(tv => tv.ArticleId);
    }
}
