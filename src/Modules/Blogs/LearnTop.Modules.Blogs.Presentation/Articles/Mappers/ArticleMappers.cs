using LearnTop.Modules.Blogs.Application.Articles.Dtos;
using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViews;
using LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.GetArticleViews;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Mappers;

internal static class ArticleMappers
{
    public static GetArticleViewsQuery ToQuery(this GetArticleViewsRequest request)
    {
        return new(
            request.Search, 
            request.Status,
            request.IsActive,
            request.PageIndex ?? 0,
            request.PageSize ?? 10);
    }
    public static Result<GetArticleViewsRequest.Response> ToResponse(this Result<GetArticleViewsResult> result)
    {
        if (result.IsFailure)
        {
            return Result.Failure<GetArticleViewsRequest.Response>(result.Error);
        }
        List<ArticleDto> articleDtos = [.. result.Value.PaginatedArticleViews.Data.Select(aw=> new ArticleDto()
        {
            Title = aw.Title,
            Content = aw.Content,
            AuthorId = aw.AuthorId,
            CategoryId = aw.CategoryId,
            Status = aw.Status,
            Visit = aw.Visit,
            IsDeleted = aw.IsDeleted,
            ShortContent = aw.ShortContent,
            CoverName = aw.CoverName,
        })];
        PaginatedResult<ArticleDto> paginatedResponse = new(result.Value.PaginatedArticleViews.PageIndex,
            result.Value.PaginatedArticleViews.PageSize, result.Value.PaginatedArticleViews.Count, articleDtos);
        
        return new GetArticleViewsRequest.Response(paginatedResponse);
    }
}
