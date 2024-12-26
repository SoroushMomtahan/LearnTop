using LearnTop.Modules.Blogs.Domain.Articles.Models;

namespace LearnTop.Modules.Blogs.Domain.Articles.Repositories;

public interface IArticleRepository
{
    Task CreateAsync(Article article);
    Task UpdateAsync(Article article);
    Task DeleteAsync(Article article);
    Task<Article?> GetByIdAsync(Guid id);
    Task UpdateTagsAsync(Article article);
    Task DeleteTagAsync(Tag tag);
}
