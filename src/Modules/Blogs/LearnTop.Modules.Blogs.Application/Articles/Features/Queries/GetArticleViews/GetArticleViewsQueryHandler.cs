﻿using LearnTop.Modules.Blogs.Application.Articles.Dtos;
using LearnTop.Modules.Blogs.Application.Views.ArticleViews;
using LearnTop.Modules.Blogs.Application.Views.ArticleViews.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViews;

internal sealed class GetArticleViewsQueryHandler(IArticleViewRepository articleViewRepository)
    : IQueryHandler<GetArticleViewsQuery, GetArticleViewsResponse>
{

    public async Task<Result<GetArticleViewsResponse>> Handle(
        GetArticleViewsQuery request, 
        CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        long totalCount = await articleViewRepository.GetTotalCountAsync();
        List<ArticleView> articleViews = await articleViewRepository.GetAllAsync(pageIndex, pageSize);
        PaginatedResult<ArticleView> paginatedArticles = new
            (
            pageIndex,
            pageSize,
            totalCount,
            articleViews
            );
        return new GetArticleViewsResponse(paginatedArticles);
    }
}
