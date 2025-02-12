using LearnTop.Modules.Categories.Domain.Categories.Models;
using LearnTop.Modules.Categories.Domain.Categories.Repositories;
using LearnTop.Modules.Categories.Infrastructure.Data.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Categories.Infrastructure.Categories.Repositories;

internal sealed class CategoryRepository(CategoriesDbContext categoriesDbContext) : ICategoryRepository
{

    public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
    {
        await categoriesDbContext.Categories.AddAsync(category, cancellationToken);
    }
    public async Task<Category?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await categoriesDbContext.Categories
            .Include(c => c.ParentCategories)
            .Include(c => c.ChildCategories)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
    public async Task<Category?> GetAsync(string name, CancellationToken cancellationToken = default)
    {
        return await categoriesDbContext.Categories
            .Include(c => c.ParentCategories)
            .Include(c => c.ChildCategories)
            .FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
    }
}
