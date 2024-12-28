using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Modules.Blogs.Infrastructure.ReadDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.ArticleViews;

public class ArticleTagViewRepository(BlogViewsDbContext blogViewsDbContext) : IArticleTagViewRepository
{

    public void Update(ArticleTagView articleTagView)
    {
        blogViewsDbContext.Entry(articleTagView).State = EntityState.Modified;
    }
    public async Task AddAsync(ArticleTagView articleTagView)
    {
        await blogViewsDbContext.AddAsync(articleTagView);
    }
    public void Delete(ArticleTagView articleTagView)
    {
        blogViewsDbContext.Entry(articleTagView).State = EntityState.Deleted;
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await blogViewsDbContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<ArticleTagView?> GetArticleTagViewAsync(Guid articleId, Guid tagId)
    {
        ArticleTagView? articleTagView = await blogViewsDbContext.ArticleTagViews
            .FirstOrDefaultAsync(x => x.ArticleId == articleId && x.TagId == tagId);
        return articleTagView;
    }
}
