using LearnTop.Modules.Blogs.Domain.Lookups.Categories.Models;

namespace LearnTop.Modules.Blogs.Domain.Lookups.Categories.Repositories;

public interface ICategoryLookupRepository
{
    Task<Category?> GetByIdAsync(Guid id);
    Task CreateAsync(Category category);
}
