using LearnTop.Modules.Information.Domain.Banners.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnTop.Modules.Academy.Infrastructure.Banners.Configurations;

internal sealed class BannerSettingConfiguration : IEntityTypeConfiguration<BannerSetting>
{

    public void Configure(EntityTypeBuilder<BannerSetting> builder)
    {
        builder.Ignore(b => b.DeletedAt);
        builder.HasData(
            BannerSetting.InitialSetting);
    }
}
