using LearnTop.Modules.Blogs.Domain.Blogs.Views;

namespace LearnTop.Modules.Blogs.Domain.Blogs.Repositories;

public interface IBlogViewRepository
{
    Task<BlogView?> GetById(Guid blogId);
    Task<List<BlogView>?> GetAll(int pageIndex = 0, int pageSize = 10, bool containDeleted = false);
    Task<List<BlogView>?> GetByCategoryId(Guid categoryId, int pageIndex = 0, int pageSize = 10, bool containDeleted = false);
    Task<List<BlogView>?> GetByTagIds(List<Guid> tagIds, int pageIndex = 0, int pageSize = 10, bool containDeleted = false);
    Task<List<BlogView>?> GetByAuthorId(Guid authorId, int pageIndex = 0, int pageSize = 10, bool containDeleted = false);
    Task<List<BlogView>?> GetBySearch(string search, int pageIndex = 0, int pageSize = 10, bool containDeleted = false);
}
