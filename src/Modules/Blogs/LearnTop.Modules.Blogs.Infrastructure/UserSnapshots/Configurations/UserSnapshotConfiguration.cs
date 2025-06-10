using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Blogs.Infrastructure.UserSnapshots.Configurations;

internal sealed class UserSnapshotConfiguration : IEntityTypeConfiguration<UserSnapshot>
{

    public void Configure(EntityTypeBuilder<UserSnapshot> builder)
    {
        builder.HasKey(x => x.UserId);
    }
}
