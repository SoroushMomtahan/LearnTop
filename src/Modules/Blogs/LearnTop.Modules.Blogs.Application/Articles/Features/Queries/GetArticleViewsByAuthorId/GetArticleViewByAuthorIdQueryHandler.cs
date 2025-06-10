using LearnTop.Modules.Blogs.Application.Views.ArticleViews;
using LearnTop.Modules.Blogs.Application.Views.ArticleViews.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByAuthorId;

internal sealed class GetArticleViewByAuthorIdQueryHandler(IArticleViewRepository articleViewRepository)
    : IQueryHandler<GetArticleViewByAuthorIdQuery, GetArticleViewByAuthorIdResponse>
{

    public async Task<Result<GetArticleViewByAuthorIdResponse>> Handle(GetArticleViewByAuthorIdQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        long totalCount = await articleViewRepository.GetTotalCountAsync();

        List<ArticleView> articleViews = await articleViewRepository
            .GetByAuthorIdAsync(request.AuthorId, pageIndex, pageSize);
        
        PaginatedResult<ArticleView> paginatedViews =
            new(pageIndex, pageSize, totalCount, articleViews);
        
        return new GetArticleViewByAuthorIdResponse(paginatedViews);
    }
}
