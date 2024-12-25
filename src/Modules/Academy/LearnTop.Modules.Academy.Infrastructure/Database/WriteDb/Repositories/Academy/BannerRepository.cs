using LearnTop.Modules.Academy.Domain.Academy.Models;
using LearnTop.Modules.Academy.Domain.Academy.Repositories;

namespace LearnTop.Modules.Academy.Infrastructure.Database.WriteDb.Repositories.Academy;

public class BannerRepository(
    AcademyDbContext dbContext
    )
    : IBannerRepository
{

    public async Task AddAsync(Banner banner)
    {
        await dbContext.Banners.AddAsync(banner);
    }
}
