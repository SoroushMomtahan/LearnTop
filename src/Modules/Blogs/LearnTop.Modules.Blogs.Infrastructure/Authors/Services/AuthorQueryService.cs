using LearnTop.Modules.Blogs.Application.Authors.Services;
using LearnTop.Modules.Blogs.Application.Authors.Views;
using LearnTop.Modules.Blogs.Infrastructure.Data.ReadDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.Authors.Services;

internal sealed class AuthorQueryService(BlogsViewsDbContext blogsViewsDbContext) : IAuthorQueryService
{

    public async Task<AuthorView?> GetAsync(Guid authorId)
    {
        return await blogsViewsDbContext.AuthorViews.FirstOrDefaultAsync(x => x.Id == authorId);
    }
    public async Task CreateAsync(AuthorView authorView, CancellationToken cancellationToken = default)
    {
        await blogsViewsDbContext.AuthorViews.AddAsync(authorView, cancellationToken);
    }
    public void Update(AuthorView authorView)
    {
        blogsViewsDbContext.Entry(authorView).State = EntityState.Modified;
    }
    public void Delete(AuthorView authorView)
    {
        blogsViewsDbContext.AuthorViews.Remove(authorView);
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await blogsViewsDbContext.SaveChangesAsync(cancellationToken);
    }
}
