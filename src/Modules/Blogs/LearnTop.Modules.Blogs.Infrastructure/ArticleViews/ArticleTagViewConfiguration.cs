using LearnTop.Modules.Blogs.Domain.Articles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Blogs.Infrastructure.ArticleViews;

public class ArticleTagViewConfiguration : IEntityTypeConfiguration<ArticleTag>
{

    public void Configure(EntityTypeBuilder<ArticleTag> builder)
    {
        builder.Ignore(x => x.Id);
        builder.Ignore(t => t.DeletedAt);
        builder.HasKey(x => new { x.ArticleId, x.TagId });
    }
}
