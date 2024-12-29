using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Blogs.Infrastructure.ArticleViews;

public class ArticleTagViewConfiguration : IEntityTypeConfiguration<ArticleTagView>
{
    public void Configure(EntityTypeBuilder<ArticleTagView> builder)
    {
        builder.Ignore(x => x.Id);
        builder.Ignore(t => t.DeletedAt);
        builder.HasKey(x => new { x.ArticleId, x.TagId });
    }
}
