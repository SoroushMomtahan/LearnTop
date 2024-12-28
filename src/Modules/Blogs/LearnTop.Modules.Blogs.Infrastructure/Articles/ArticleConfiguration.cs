using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Blogs.Infrastructure.Articles;

internal sealed class ArticleConfiguration : IEntityTypeConfiguration<Domain.Articles.Models.Article>
{

    public void Configure(EntityTypeBuilder<Domain.Articles.Models.Article> builder)
    {
        builder.Property(a => a.AuthorId)
            .IsRequired();
        builder.Property(a => a.CategoryId)
            .IsRequired();
        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(a => a.Content)
            .IsRequired();
        builder.Property(a => a.Status)
            .IsRequired()
            .HasConversion<string>();
        builder.HasMany(a => a.Tags)
            .WithOne(t => t.Article)
            .HasForeignKey(t => t.ArticleId);
    }
}
