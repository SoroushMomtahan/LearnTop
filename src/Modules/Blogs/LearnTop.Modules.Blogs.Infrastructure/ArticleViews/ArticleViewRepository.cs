using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Modules.Blogs.Infrastructure.ReadDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.ArticleViews;

public class ArticleViewRepository(BlogViewsDbContext viewsDbContext) : IArticleViewRepository
{

    public async Task<ArticleView?> GetByIdAsync(Guid articleId)
    {
        return await viewsDbContext.ArticleViews
            .Include(x => x.TagViews)
            .FirstOrDefaultAsync(x => x.Id == articleId);
    }
    public async Task<List<ArticleView>> GetAllAsync(int pageIndex, int pageSize, bool includeDeletedRows = false)
    {
        List<ArticleView> articleViews = await viewsDbContext.ArticleViews
            .AsNoTracking()
            .Include(x => x.TagViews)
            .AsNoTracking()
            .Where(x => x.IsDeleted == includeDeletedRows)
            .OrderByDescending(x => x.CreatedAt)
            .Skip(pageIndex)
            .Take(pageSize)
            .ToListAsync();
        return articleViews;
    }
    public async Task<List<ArticleView>> GetByCategoryIdAsync(Guid categoryId, int pageIndex, int pageSize,
        bool includeDeletedRows = false)
    {
        return await viewsDbContext.ArticleViews
            .AsNoTracking()
            .Include(x => x.TagViews)
            .Where(x => x.CategoryId == categoryId)
            .Where(x => x.IsDeleted == includeDeletedRows)
            .OrderByDescending(x => x.CreatedAt)
            .Skip(pageIndex)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<List<ArticleView>> GetByTagIdsAsync(List<Guid> tagIds, int pageIndex, int pageSize,
        bool includeDeletedRows = false)
    {
        return await viewsDbContext.ArticleViews
            .AsNoTracking()
            .Include(x => x.TagViews)
            .Where(x => x.TagViews.Any(t => tagIds.Contains(t.TagId)))
            .Where(x => x.IsDeleted == includeDeletedRows)
            .OrderByDescending(x => x.CreatedAt)
            .Skip(pageIndex)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<List<ArticleView>> GetByAuthorIdAsync(Guid authorId, int pageIndex, int pageSize,
        bool includeDeletedRows = false)
    {
        return await viewsDbContext.ArticleViews
            .AsNoTracking()
            .Include(x => x.TagViews)
            .Where(x => x.AuthorId == authorId)
            .Where(x => x.IsDeleted == includeDeletedRows)
            .OrderByDescending(x => x.CreatedAt)
            .Skip(pageIndex)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<List<ArticleView>> GetBySearchAsync(string search, int pageIndex, int pageSize,
        bool includeDeletedRows = false)
    {
        return await viewsDbContext.ArticleViews
            .AsNoTracking()
            .Include(x => x.TagViews)
            .Where(x => x.Title.Contains(search) || x.Content.Contains(search))
            .Where(x => x.IsDeleted == includeDeletedRows)
            .OrderByDescending(x => x.CreatedAt)
            .Skip(pageIndex)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<long> GetTotalCountAsync()
    {
        return await viewsDbContext.ArticleViews.LongCountAsync();
    }
    public async Task AddAsync(ArticleView articleView)
    {
        await viewsDbContext.ArticleViews.AddAsync(articleView);
    }
    public void Update(ArticleView articleView)
    {
        viewsDbContext.Entry(articleView).State = EntityState.Modified;
    }
    public void Delete(ArticleView articleView)
    {
        viewsDbContext.Entry(articleView).State = EntityState.Deleted;
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await viewsDbContext.SaveChangesAsync(cancellationToken);
    }
}
