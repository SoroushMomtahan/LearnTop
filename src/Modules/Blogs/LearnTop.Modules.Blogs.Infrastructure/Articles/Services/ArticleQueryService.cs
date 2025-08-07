using LearnTop.Modules.Blogs.Application.Articles.Services;
using LearnTop.Modules.Blogs.Application.Articles.Views;
using LearnTop.Modules.Blogs.Infrastructure.Data.ReadDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.Articles.Services;

public class ArticleQueryService(BlogsViewsDbContext viewsDbContext) : IArticleQueryService
{

    public async Task<ArticleView?> GetByIdAsync(Guid articleId)
    {
        ArticleView articleView = await viewsDbContext.ArticleViews
            .FirstOrDefaultAsync(x => x.Id == articleId);

        return articleView;
    }
    public async Task<List<ArticleView>> GetAllAsync(int pageIndex, int pageSize, bool? isActive, string? search, string? status)
    {
        List<ArticleView> articleViews = await viewsDbContext.ArticleViews
            .AsNoTracking()
            .Where(x => isActive == null || x.IsDeleted == !isActive)
            .Where(x =>
                search == null ||
                x.Title.Contains(search) ||
                x.ShortContent.Contains(search) ||
                x.Content.Contains(search))
            .Where(x =>
                status == null ||
                x.Status == status.ToString())
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
            .Where(x => x.TagIds.TrueForAll(tagIds.Contains))
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
            .Where(x => x.Title.Contains(search) || x.Content.Contains(search) || x.ShortContent.Contains(search))
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
    public async Task BulkUpdateByAuthorIdAsync(Guid authorId, string username, string? displayName,
        CancellationToken cancellationToken = default)
    {
        await viewsDbContext.ArticleViews
            .Where(x => x.AuthorId == authorId)
            .ExecuteUpdateAsync(update=>
                update
                    .SetProperty(av=>av.AuthorUsername, username)
                    .SetProperty(av=>av.AuthorDisplayName, displayName),
                cancellationToken);
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await viewsDbContext.SaveChangesAsync(cancellationToken);
    }
}
