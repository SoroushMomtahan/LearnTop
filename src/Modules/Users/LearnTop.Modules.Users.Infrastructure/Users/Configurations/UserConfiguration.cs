using LearnTop.Modules.Users.Domain.Users.Models;
using LearnTop.Modules.Users.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Users.Infrastructure.Users.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.OwnsOne(u => u.Firstname, firstname =>
        {
            firstname.Property(x => x.Value)
                .HasColumnName(nameof(Firstname))
                .IsRequired(false)
                .HasMaxLength(20);
        });
        
        builder.OwnsOne(u => u.Lastname, lastname =>
        {
            lastname.Property(x => x.Value)
                .HasColumnName(nameof(Lastname))
                .IsRequired(false)
                .HasMaxLength(50);
        });

        builder.Property(u => u.Fullname)
            .IsRequired(false);
        
        builder.Property(u=>u.IdentityUser)
            .IsRequired();
    }
}
