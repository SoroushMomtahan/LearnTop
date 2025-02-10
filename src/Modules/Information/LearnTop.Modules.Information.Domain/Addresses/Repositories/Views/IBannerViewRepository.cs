using LearnTop.Modules.Information.Domain.Addresses.ViewModels;

namespace LearnTop.Modules.Information.Domain.Addresses.Repositories.Views;

public interface IBannerViewRepository
{
    Task<List<BannerView>> GetAllAsync();
    Task<BannerView> GetByIdAsync(Guid id);
    Task AddAsync(BannerView bannerView);
    void Update(BannerView bannerView);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
