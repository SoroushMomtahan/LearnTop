using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Models;

namespace LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Repositories;

public interface IArticleRepository
{
    Task CreateAsync(Article article);
    void Delete(Article article);
    Task<Article?> GetByIdAsync(Guid id);
}
