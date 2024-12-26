using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewById;

internal sealed class GetArticleViewByIdQueryHandler(IArticleViewRepository articleViewRepository)
    : IQueryHandler<GetArticleViewByIdQuery, GetArticleViewByIdResponse>
{

    public async Task<Result<GetArticleViewByIdResponse>> Handle(GetArticleViewByIdQuery request, CancellationToken cancellationToken)
    {
        ArticleView? articleView = await articleViewRepository.GetByIdAsync(request.ArticleId);
        
        return articleView is null 
            ? Result.Failure<GetArticleViewByIdResponse>(ArticleErrors.NotFound(request.ArticleId)) 
            : new GetArticleViewByIdResponse(articleView);
    }
}
