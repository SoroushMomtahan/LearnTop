using LearnTop.Modules.Academy.Domain.Academy.Models;

namespace LearnTop.Modules.Academy.Domain.Academy.Repositories;

public interface IBannerRepository
{
    Task AddAsync(Banner banner);
}
