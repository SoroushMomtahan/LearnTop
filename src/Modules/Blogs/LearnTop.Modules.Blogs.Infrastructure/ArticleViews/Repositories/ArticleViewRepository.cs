using System.Runtime.Intrinsics.X86;
using LearnTop.Modules.Blogs.Application.Views.ArticleViews;
using LearnTop.Modules.Blogs.Application.Views.ArticleViews.Repositories;
using LearnTop.Modules.Blogs.Infrastructure.Data.ReadDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.ArticleViews.Repositories;

public class ArticleViewRepository(BlogsViewsDbContext viewsDbContext) : IArticleViewRepository
{

    public async Task<ArticleView?> GetByIdAsync(Guid articleId)
    {

        ArticleView articleView = await viewsDbContext.ArticleViews
            .Include(x=>x.AuthorView)
            .FirstOrDefaultAsync(x => x.Id == articleId);
        
        await IncreaseViewCount(articleView);
        
        return articleView;
    }
    private async Task IncreaseViewCount(ArticleView? articleView)
    {
        if (articleView is not null)
        {
            articleView.Visit++;
            viewsDbContext.ArticleViews.Update(articleView);
            await SaveChangesAsync();
        }
    }
    public async Task<List<ArticleView>> GetAllAsync(int pageIndex, int pageSize, bool includeDeletedRows = false)
    {
        List<ArticleView> articleViews = await viewsDbContext.ArticleViews
            .AsNoTracking()
            .Include(x=>x.AuthorView)
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
            .Include(x=>x.AuthorView)
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
            .Include(x=>x.AuthorView)
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
            .Include(x=>x.AuthorView)
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
            .Include(x=>x.AuthorView)
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
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await viewsDbContext.SaveChangesAsync(cancellationToken);
    }
}
