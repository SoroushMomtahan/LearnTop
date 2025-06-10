using LearnTop.Modules.Blogs.Application.Views.ArticleViews;
using LearnTop.Modules.Blogs.Application.Views.ArticleViews.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsBySearch;

internal sealed class GetArticleViewsBySearchQueryHandler(IArticleViewRepository articleViewRepository)
    : IQueryHandler<GetArticleViewsBySearchQuery, GetArticleViewsBySearchResponse>
{


    public async Task<Result<GetArticleViewsBySearchResponse>> Handle(GetArticleViewsBySearchQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        long totalCount = await articleViewRepository.GetTotalCountAsync();
        List<ArticleView> articleViews = 
            await articleViewRepository.GetBySearchAsync(
                request.SearchString ?? string.Empty,
                pageIndex,
                pageSize);
        
        PaginatedResult<ArticleView> paginatedArticles =
            new(pageIndex, pageSize, totalCount, articleViews);
        
        return new GetArticleViewsBySearchResponse(paginatedArticles);
    }
}
