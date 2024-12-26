using LearnTop.Modules.Blogs.Domain.Articles.Views;

namespace LearnTop.Modules.Blogs.Domain.Articles.Repositories;

public interface IArticleViewRepository
{
    Task<ArticleView?> GetById(Guid blogId);
    Task<List<ArticleView>?> GetAll(int pageIndex = 0, int pageSize = 10, bool containDeleted = false);
    Task<List<ArticleView>?> GetByCategoryId(Guid categoryId, int pageIndex = 0, int pageSize = 10, bool containDeleted = false);
    Task<List<ArticleView>?> GetByTagIds(List<Guid> tagIds, int pageIndex = 0, int pageSize = 10, bool containDeleted = false);
    Task<List<ArticleView>?> GetByAuthorId(Guid authorId, int pageIndex = 0, int pageSize = 10, bool containDeleted = false);
    Task<List<ArticleView>?> GetBySearch(string search, int pageIndex = 0, int pageSize = 10, bool containDeleted = false);
}
