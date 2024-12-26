using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.DeleteArticle;

public class DeleteArticleCommandHandler(IArticleRepository articleRepository)
    : ICommandHandler<DeleteArticleCommand, DeleteArticleResponse>
{

    public async Task<Result<DeleteArticleResponse>> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        Article? blog = await articleRepository.GetByIdAsync(request.BlogId);
        if (blog is null)
        {
            return Result.Failure<DeleteArticleResponse>(ArticleErrors.NotFound(request.BlogId));
        }
        if (request.IsLogicDelete)
        {
            blog.Delete();
            await articleRepository.UpdateAsync(blog);
        }
        else
        {
            await articleRepository.DeleteAsync(blog);
        }
        return new DeleteArticleResponse(blog.Id);
    }
}
