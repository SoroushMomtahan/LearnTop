using LearnTop.Modules.Blogs.Application.Categories.Views;
using LearnTop.Modules.Blogs.Domain.Lookups.Categories.Models;

namespace LearnTop.Modules.Blogs.Application.Categories.Services;

public interface ICategoryQueryService
{
    Task CreateCategoryAsync(CategoryView categoryView);
}
