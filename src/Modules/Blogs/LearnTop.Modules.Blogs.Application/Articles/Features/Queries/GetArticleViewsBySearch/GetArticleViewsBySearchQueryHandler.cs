﻿using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsBySearch;

internal sealed class GetArticleViewsBySearchQueryHandler(IArticleViewRepository articleViewRepository)
    : IQueryHandler<GetArticleViewsBySearchQuery, GetArticleViewsBySearchResponse>
{


    public async Task<Result<GetArticleViewsBySearchResponse>> Handle(GetArticleViewsBySearchQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.Request.PageIndex;
        int pageSize = request.Request.PageSize;
        long totalCount = await articleViewRepository.GetTotalCountAsync();
        List<ArticleView> articleViews = 
            await articleViewRepository.GetBySearchAsync(
                request.SearchString,
                pageIndex,
                pageSize);
        
        PaginatedResult<ArticleView> paginatedArticles =
            new(pageIndex, pageSize, totalCount, articleViews);
        
        return new GetArticleViewsBySearchResponse(paginatedArticles);
    }
}