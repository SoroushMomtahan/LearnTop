using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Repositories;
using LearnTop.Modules.Blogs.Infrastructure.Data.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.Articles.Repositories;

internal sealed class ArticleRepository(BlogsDbContext blogsDbContext) : IArticleRepository
{

    public async Task CreateAsync(Article article)
    {
        await blogsDbContext.Articles.AddAsync(article);
    }
    public void Delete(Article article)
    {
        blogsDbContext.Entry(article).State = EntityState.Deleted;
    }
    public async Task<Article?> GetByIdAsync(Guid id)
    {
        Article? article = await blogsDbContext.Articles
            .FirstOrDefaultAsync(a => a.Id == id);
        return article;
    }
}
