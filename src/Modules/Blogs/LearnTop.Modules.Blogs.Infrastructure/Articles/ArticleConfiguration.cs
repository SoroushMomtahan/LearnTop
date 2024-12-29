using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Blogs.Infrastructure.Articles;

internal sealed class ArticleConfiguration : IEntityTypeConfiguration<Article>
{

    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.Property(a => a.AuthorId)
            .IsRequired();
        builder.Property(a => a.CategoryId)
            .IsRequired();
        builder.OwnsOne(a => a.Title, title =>
        {
            title.Property(t => t.Value)
                .HasColumnName(nameof(Title))
                .IsRequired()
                .HasMaxLength(100);
        });

        builder.OwnsOne(a => a.Content, content =>
        {
            content.Property(a => a.Value)
                .HasColumnName(nameof(Content))
                .IsRequired();
        });
        builder.Property(a => a.Status)
            .IsRequired()
            .HasConversion<string>();
        builder.HasMany(a => a.Tags)
            .WithOne(t => t.Article)
            .HasForeignKey(t => t.ArticleId);
    }
}
