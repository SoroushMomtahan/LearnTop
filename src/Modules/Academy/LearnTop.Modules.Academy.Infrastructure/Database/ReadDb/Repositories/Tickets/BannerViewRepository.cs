using LearnTop.Modules.Academy.Domain.Academy.Repositories.Views;
using LearnTop.Modules.Academy.Domain.Academy.ViewModels;

namespace LearnTop.Modules.Academy.Infrastructure.Database.ReadDb.Repositories.Tickets;

public class BannerViewRepository : IBannerViewRepository
{

    public Task<List<BannerView>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    public Task<BannerView> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
    public Task AddAsync(BannerView bannerView)
    {
        throw new NotImplementedException();
    }
    public void Update(BannerView bannerView)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
