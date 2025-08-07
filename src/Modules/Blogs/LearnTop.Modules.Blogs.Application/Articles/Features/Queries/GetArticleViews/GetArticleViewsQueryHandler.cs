using LearnTop.Modules.Blogs.Application.Articles.Services;
using LearnTop.Modules.Blogs.Application.Articles.Views;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViews;

internal sealed class GetArticleViewsQueryHandler(IArticleQueryService articleQueryService)
    : IQueryHandler<GetArticleViewsQuery, GetArticleViewsResult>
{

    public async Task<Result<GetArticleViewsResult>> Handle(
        GetArticleViewsQuery request, 
        CancellationToken cancellationToken)
    {
        int pageIndex = request.PageIndex;
        int pageSize = request.PageSize;
        
        long totalCount = await articleQueryService.GetTotalCountAsync();
        
        string? search = request.Search?.Trim().ToLowerInvariant();
        
        List<ArticleView> articleViews = await articleQueryService.GetAllAsync(
            pageIndex, 
            pageSize, 
            request.IsActive, 
            search, 
            request.Status.ToString());
        PaginatedResult<ArticleView> paginatedArticles = new
            (
            pageIndex,
            pageSize,
            totalCount,
            articleViews
            );
        return new GetArticleViewsResult(paginatedArticles);
    }
}
