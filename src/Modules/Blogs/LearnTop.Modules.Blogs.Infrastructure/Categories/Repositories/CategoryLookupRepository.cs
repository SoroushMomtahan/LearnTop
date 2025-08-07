using LearnTop.Modules.Blogs.Domain.Lookups.Categories.Models;
using LearnTop.Modules.Blogs.Domain.Lookups.Categories.Repositories;
using LearnTop.Modules.Blogs.Infrastructure.Data.WriteDb;

namespace LearnTop.Modules.Blogs.Infrastructure.Categories.Repositories;

internal sealed class CategoryLookupRepository(BlogsDbContext blogsDbContext) : ICategoryLookupRepository
{

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await blogsDbContext.Categories.FindAsync(id);
    }
    public async Task CreateAsync(Category category)
    {
        await blogsDbContext.Categories.AddAsync(category);
    }
}
