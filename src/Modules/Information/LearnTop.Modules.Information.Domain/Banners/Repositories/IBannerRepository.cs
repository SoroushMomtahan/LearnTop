using LearnTop.Modules.Information.Domain.Banners.Models;

namespace LearnTop.Modules.Information.Domain.Banners.Repositories;

public interface IBannerRepository
{
    Task CreateAsync(Banner banner, CancellationToken cancellationToken = default);
    void Delete(Banner banner);
    Task<Banner?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<BannerSetting?> GetSettingsAsync(CancellationToken cancellationToken = default);
}
