using LearnTop.Modules.Identity.Domain.Roles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Identity.Infrastructure.Roles.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{

    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasData(
            Permission.ReadDeletedArticles,
            Permission.WriteArticles,
            Permission.WriteTags,
            Permission.DeleteTags);
    }
}
