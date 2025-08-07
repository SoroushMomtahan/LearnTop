using LearnTop.Modules.Blogs.Application.Articles.Services;
using LearnTop.Modules.Blogs.Application.Articles.Views;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsBySearch;

internal sealed class GetArticleViewsBySearchQueryHandler(IArticleQueryService articleQueryService)
    : IQueryHandler<GetArticleViewsBySearchQuery, GetArticleViewsBySearchResponse>
{


    public async Task<Result<GetArticleViewsBySearchResponse>> Handle(GetArticleViewsBySearchQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        long totalCount = await articleQueryService.GetTotalCountAsync();
        List<ArticleView> articleViews = 
            await articleQueryService.GetBySearchAsync(
                request.SearchString ?? string.Empty,
                pageIndex,
                pageSize);
        
        PaginatedResult<ArticleView> paginatedArticles =
            new(pageIndex, pageSize, totalCount, articleViews);
        
        return new GetArticleViewsBySearchResponse(paginatedArticles);
    }
}
