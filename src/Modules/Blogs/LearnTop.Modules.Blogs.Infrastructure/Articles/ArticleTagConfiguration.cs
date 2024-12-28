using LearnTop.Modules.Blogs.Domain.Articles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Blogs.Infrastructure.Articles;

internal sealed class ArticleTagConfiguration : IEntityTypeConfiguration<ArticleTag>
{

    public void Configure(EntityTypeBuilder<ArticleTag> builder)
    {
        builder.Ignore(t=>t.Id);
        builder.Ignore(t => t.DeletedAt);
        builder.HasKey(t => new { t.TagId, t.ArticleId });
    }
}
