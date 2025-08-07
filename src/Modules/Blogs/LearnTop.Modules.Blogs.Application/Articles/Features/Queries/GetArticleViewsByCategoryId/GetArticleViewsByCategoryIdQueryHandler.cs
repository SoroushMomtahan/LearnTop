using LearnTop.Modules.Blogs.Application.Articles.Services;
using LearnTop.Modules.Blogs.Application.Articles.Views;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByCategoryId;

internal sealed class GetArticleViewsByCategoryIdQueryHandler(IArticleQueryService articleQueryService)
    : IQueryHandler<GetArticleViewsByCategoryIdQuery, GetArticleViewsByCategoryIdResponse>
{

    public async Task<Result<GetArticleViewsByCategoryIdResponse>> Handle(GetArticleViewsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        long totalCount = await articleQueryService.GetTotalCountAsync();
        List<ArticleView> articleViews = await articleQueryService
            .GetByCategoryIdAsync(
                request.CategoryId,
                pageIndex,
                pageSize);
        PaginatedResult<ArticleView> paginatedArticleViews = 
            new(pageIndex, pageSize, totalCount, articleViews);
        return new GetArticleViewsByCategoryIdResponse(paginatedArticleViews);
    }
}
