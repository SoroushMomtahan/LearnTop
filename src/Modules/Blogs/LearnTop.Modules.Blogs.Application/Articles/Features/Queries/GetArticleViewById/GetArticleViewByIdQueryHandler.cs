using LearnTop.Modules.Blogs.Application.Articles.Services;
using LearnTop.Modules.Blogs.Application.Articles.Views;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Errors;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewById;

internal sealed class GetArticleViewByIdQueryHandler(IArticleQueryService articleQueryService)
    : IQueryHandler<GetArticleViewByIdQuery, GetArticleViewByIdResponse>
{

    public async Task<Result<GetArticleViewByIdResponse>> Handle(
        GetArticleViewByIdQuery request, CancellationToken cancellationToken)
    {
        ArticleView? articleView = await articleQueryService.GetByIdAsync(request.ArticleId);
        
        return articleView is null ? 
            Result.Failure<GetArticleViewByIdResponse>(ArticleErrors.NotFound(request.ArticleId)) :
            new GetArticleViewByIdResponse(articleView);
    }
}
