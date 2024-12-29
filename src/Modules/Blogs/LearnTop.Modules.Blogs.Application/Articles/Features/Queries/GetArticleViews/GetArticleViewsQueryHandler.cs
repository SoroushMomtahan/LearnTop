using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViews;

internal sealed class GetArticleViewsQueryHandler(IArticleViewRepository articleViewRepository)
    : IQueryHandler<GetArticleViewsQuery, GetArticleViewsResponse>
{

    public async Task<Result<GetArticleViewsResponse>> Handle(GetArticleViewsQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        bool includeDeletedRows = request.PaginationRequest.IncludeDeletedRows;
        long totalCount = await articleViewRepository.GetTotalCountAsync();
        List<ArticleView> articleViews = await articleViewRepository.GetAllAsync(pageIndex, pageSize, includeDeletedRows);
        PaginatedResult<ArticleView> articleViewsPaginated = new
            (
            pageIndex,
            pageSize,
            totalCount,
            articleViews
            );
        return new GetArticleViewsResponse(articleViewsPaginated);
    }
}
