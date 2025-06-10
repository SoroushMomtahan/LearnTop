using LearnTop.Modules.Files.Domain.Files.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Files.Infrastructure.Files.Db.Configurations;

internal sealed class ImageFileConfiguration : IEntityTypeConfiguration<ImageFileSetting>
{

    public void Configure(EntityTypeBuilder<ImageFileSetting> builder)
    {
        builder.Ignore(x => x.CreatedAt);
        builder.Ignore(x => x.UpdatedAt);
        builder.Ignore(x => x.DeletedAt);

        builder.HasData(ImageFileSetting.InitialSettings);
    }
}
