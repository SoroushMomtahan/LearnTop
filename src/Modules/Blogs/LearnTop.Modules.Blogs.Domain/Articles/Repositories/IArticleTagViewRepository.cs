using LearnTop.Modules.Blogs.Domain.Articles.Views;

namespace LearnTop.Modules.Blogs.Domain.Articles.Repositories;

public interface IArticleTagViewRepository
{
    void Update(ArticleTagView articleTagView);
    Task AddAsync(ArticleTagView articleTagView);
    void Delete(ArticleTagView articleTagView);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<ArticleTagView?> GetArticleTagViewAsync(Guid articleId, Guid tagId);
}
