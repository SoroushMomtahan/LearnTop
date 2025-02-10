using LearnTop.Modules.Academy.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Information.Domain.Banners.Models;
using LearnTop.Modules.Information.Domain.Banners.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Academy.Infrastructure.Banners.Repositories;

internal sealed class BannerRepository(
    InformationDbContext informationDbContext) : IBannerRepository
{

    public async Task CreateAsync(Banner banner, CancellationToken cancellationToken = default)
    {
        await informationDbContext.Banners.AddAsync(banner, cancellationToken);
    }
    public void Delete(Banner banner)
    {
        informationDbContext.Banners.Remove(banner);
    }
    public async Task<Banner?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await informationDbContext.Banners
            .Where(b => b.Id == id)
            .SingleOrDefaultAsync(cancellationToken);
    }
    public async Task<BannerSetting?> GetSettingsAsync(CancellationToken cancellationToken = default)
    {
        return await informationDbContext.BannerSettings.FirstOrDefaultAsync(cancellationToken);
    }
}
