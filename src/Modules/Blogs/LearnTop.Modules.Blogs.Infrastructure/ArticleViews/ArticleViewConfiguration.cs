using LearnTop.Modules.Blogs.Domain.Articles.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Blogs.Infrastructure.ArticleViews;

public class ArticleViewConfiguration : IEntityTypeConfiguration<ArticleView>
{

    public void Configure(EntityTypeBuilder<ArticleView> builder)
    {
        builder.HasMany(av => av.Tags)
            .WithOne(at => at.ArticleView)
            .HasForeignKey(tv => tv.ArticleId);
    }
}
