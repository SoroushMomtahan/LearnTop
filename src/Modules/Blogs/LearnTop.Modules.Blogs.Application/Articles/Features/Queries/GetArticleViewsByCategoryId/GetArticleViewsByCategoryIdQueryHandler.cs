using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByCategoryId;

internal sealed class GetArticleViewsByCategoryIdQueryHandler(IArticleViewRepository articleViewRepository)
    : IQueryHandler<GetArticleViewsByCategoryIdQuery, GetArticleViewsByCategoryIdResponse>
{

    public async Task<Result<GetArticleViewsByCategoryIdResponse>> Handle(GetArticleViewsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.Request.PageIndex;
        int pageSize = request.Request.PageSize;
        long totalCount = await articleViewRepository.GetTotalCountAsync();
        List<ArticleView> articleViews = await articleViewRepository
            .GetByCategoryIdAsync(
                request.CategoryId,
                pageIndex,
                pageSize);
        PaginatedResult<ArticleView> paginatedArticleViews = 
            new(pageIndex, pageSize, totalCount, articleViews);
        return new GetArticleViewsByCategoryIdResponse(paginatedArticleViews);
    }
}
