using LearnTop.Modules.Commenting.Domain.Comments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Commenting.Infrastructure.Comments.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{

    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasMany(c => c.Replies)
            .WithOne(c => c.MainComment)
            .HasForeignKey(c => c.ParentCommentId)
            .IsRequired(false);
    }
}
