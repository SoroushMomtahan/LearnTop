using LearnTop.Modules.Blogs.Application.Views.ArticleViews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Blogs.Infrastructure.ArticleViews.Configurations;

internal sealed class ArticleViewConfiguration : IEntityTypeConfiguration<ArticleView>
{

    public void Configure(EntityTypeBuilder<ArticleView> builder)
    {
        builder.HasOne(x=>x.AuthorView)
            .WithMany()
            .HasForeignKey(x => x.AuthorId);
    }
}
