using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Infrastructure.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.Articles;

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
            .Include(a=>a.Tags)
            .FirstOrDefaultAsync(a => a.Id == id);
        return article;
    }
}
