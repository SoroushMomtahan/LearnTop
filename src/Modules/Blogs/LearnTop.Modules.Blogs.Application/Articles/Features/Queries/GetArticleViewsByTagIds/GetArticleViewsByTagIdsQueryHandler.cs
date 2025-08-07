using LearnTop.Modules.Blogs.Application.Articles.Services;
using LearnTop.Modules.Blogs.Application.Articles.Views;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByTagIds;

internal sealed class GetArticleViewsByTagIdsQueryHandler(IArticleQueryService articleQueryService)
    : IQueryHandler<GetArticleViewsByTagIdsQuery, GetArticleViewsByTagIdsResponse>
{


    public async Task<Result<GetArticleViewsByTagIdsResponse>> Handle(GetArticleViewsByTagIdsQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        long totalCount = await articleQueryService.GetTotalCountAsync();
        
        List<ArticleView> articleViews = await articleQueryService
            .GetByTagIdsAsync(request.TagIds, pageIndex, pageSize);
        
        PaginatedResult<ArticleView> paginatedViews = 
            new(pageIndex, pageSize, totalCount, articleViews);
        
        return new GetArticleViewsByTagIdsResponse(paginatedViews);
    }
}
