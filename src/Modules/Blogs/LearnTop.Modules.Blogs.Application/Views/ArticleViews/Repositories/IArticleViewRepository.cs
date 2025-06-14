﻿namespace LearnTop.Modules.Blogs.Application.Views.ArticleViews.Repositories;

public interface IArticleViewRepository
{
    Task<ArticleView?> GetByIdAsync(Guid articleId);
    Task<List<ArticleView>> GetAllAsync(int pageIndex, int pageSize, bool includeDeletedRows = false);
    Task<List<ArticleView>> GetByCategoryIdAsync(Guid categoryId, int pageIndex, int pageSize, bool includeDeletedRows = false);
    Task<List<ArticleView>> GetByTagIdsAsync(List<Guid> tagIds, int pageIndex, int pageSize, bool includeDeletedRows = false);
    Task<List<ArticleView>> GetByAuthorIdAsync(Guid authorId, int pageIndex, int pageSize, bool includeDeletedRows = false);
    Task<List<ArticleView>> GetBySearchAsync(string search, int pageIndex, int pageSize, bool includeDeletedRows = false);
    Task<long> GetTotalCountAsync();
    Task AddAsync(ArticleView articleView);
    void Update(ArticleView articleView);
    void Delete(ArticleView articleView);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
