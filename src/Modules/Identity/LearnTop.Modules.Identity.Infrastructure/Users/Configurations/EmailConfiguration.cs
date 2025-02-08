using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Modules.Identity.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Identity.Infrastructure.Users.Configurations;

public class EmailConfiguration : IEntityTypeConfiguration<Email>
{

    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.OwnsOne(e => e.Verify, verify =>
        {
            verify.Property(v => v.Code)
                .HasColumnName(nameof(Verify.Code));
            verify.Property(v => v.Status)
                .HasColumnName(nameof(Verify.Status));
            verify.Property(v => v.ExpireIn)
                .HasColumnName(nameof(Verify.ExpireIn));
        });
        builder.HasAlternateKey(e=>e.Address);
    }
}
