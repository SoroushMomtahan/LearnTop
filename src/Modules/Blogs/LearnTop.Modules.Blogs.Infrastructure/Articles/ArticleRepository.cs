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
    public void Update(Article article)
    {
        blogsDbContext.Articles.Update(article);
        foreach (ArticleTag articleTag in article.Tags)
        {
            blogsDbContext.Tags.Add(articleTag);
        }
    }
    public void Delete(Article article)
    {
        blogsDbContext.Articles.Remove(article);
    }
    public async Task<Article?> GetByIdAsync(Guid id)
    {
        Article? article = await blogsDbContext.Articles
            .FirstOrDefaultAsync(a => a.Id == id);
        return article;
    }
    public void DeleteTag(ArticleTag articleTag)
    {
        blogsDbContext.Tags.Remove(articleTag);
    }
}
