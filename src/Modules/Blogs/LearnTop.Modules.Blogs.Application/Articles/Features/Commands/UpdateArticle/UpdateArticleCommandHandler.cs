using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.UpdateArticle;

internal sealed class UpdateArticleCommandHandler(IArticleRepository articleRepository) 
    :ICommandHandler<UpdateArticleCommand, UpdateArticleResponse>
{

    public async Task<Result<UpdateArticleResponse>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        Article? blog = await articleRepository.GetByIdAsync(request.BlogId);
        if (blog is null)
        {
            return Result.Failure<UpdateArticleResponse>(ArticleErrors.NotFound(request.BlogId));
        }
        blog.Update(
            request.Title,
            request.Content
            );
        await articleRepository.UpdateAsync(blog);
        return new UpdateArticleResponse(blog.Id);
    }
}
