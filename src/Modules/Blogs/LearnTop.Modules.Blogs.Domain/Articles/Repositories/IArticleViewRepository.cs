using LearnTop.Modules.Blogs.Domain.Articles.Views;

namespace LearnTop.Modules.Blogs.Domain.Articles.Repositories;

public interface IArticleViewRepository
{
    Task<ArticleView?> GetByIdAsync(Guid blogId);
    Task<List<ArticleView>> GetAllAsync(int pageIndex, int pageSize, bool containDeleted = false);
    Task<List<ArticleView>> GetByCategoryIdAsync(Guid categoryId, int pageIndex, int pageSize, bool containDeleted = false);
    Task<List<ArticleView>> GetByTagIdsAsync(List<Guid> tagIds, int pageIndex, int pageSize, bool containDeleted = false);
    Task<List<ArticleView>> GetByAuthorIdAsync(Guid authorId, int pageIndex, int pageSize, bool containDeleted = false);
    Task<List<ArticleView>> GetBySearchAsync(string search, int pageIndex, int pageSize, bool containDeleted = false);
    Task<long> GetTotalCountAsync();
}
