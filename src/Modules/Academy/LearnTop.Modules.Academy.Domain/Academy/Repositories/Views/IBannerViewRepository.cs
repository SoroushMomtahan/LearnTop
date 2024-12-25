using LearnTop.Modules.Academy.Domain.Academy.ViewModels;

namespace LearnTop.Modules.Academy.Domain.Academy.Repositories.Views;

public interface IBannerViewRepository
{
    Task<List<BannerView>> GetAllAsync();
    Task<BannerView> GetByIdAsync(Guid id);
    Task AddAsync(BannerView bannerView);
    void Update(BannerView bannerView);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
