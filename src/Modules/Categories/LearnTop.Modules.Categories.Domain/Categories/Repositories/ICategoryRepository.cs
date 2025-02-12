using LearnTop.Modules.Categories.Domain.Categories.Models;

namespace LearnTop.Modules.Categories.Domain.Categories.Repositories;

public interface ICategoryRepository
{
    Task AddAsync(Category category, CancellationToken cancellationToken = default);
    
    Task<Category?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Category?> GetAsync(string name, CancellationToken cancellationToken = default);
}
