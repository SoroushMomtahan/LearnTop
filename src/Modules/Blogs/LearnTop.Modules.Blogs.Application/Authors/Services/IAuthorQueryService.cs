using LearnTop.Modules.Blogs.Application.Authors.Views;

namespace LearnTop.Modules.Blogs.Application.Authors.Services;

public interface IAuthorQueryService
{
    Task<AuthorView?> GetAsync(Guid authorId);
    Task CreateAsync(AuthorView authorView, CancellationToken cancellationToken = default);
    void Update(AuthorView authorView);
    void Delete(AuthorView authorView);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
