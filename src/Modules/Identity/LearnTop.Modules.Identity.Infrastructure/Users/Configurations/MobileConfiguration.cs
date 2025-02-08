using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Modules.Identity.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Identity.Infrastructure.Users.Configurations;

public class MobileConfiguration : IEntityTypeConfiguration<Mobile>
{

    public void Configure(EntityTypeBuilder<Mobile> builder)
    {
        builder.OwnsOne(m => m.Verify, verify =>
        {
            verify.Property(v => v.Code)
                .HasColumnName(nameof(Verify.Code));
            verify.Property(v => v.Status)
                .HasColumnName(nameof(Verify.Status));
            verify.Property(v => v.ExpireIn)
                .HasColumnName(nameof(Verify.ExpireIn));
        });
        builder.HasAlternateKey(m=>m.Number);
    }
}
