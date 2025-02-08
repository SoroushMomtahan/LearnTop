using LearnTop.Modules.Identity.Domain.Roles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Identity.Infrastructure.Roles.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasMany(r => r.Permissions)
            .WithMany();

        builder.HasData(
            Role.User,
            Role.Admin);
    }
}
