using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.AddArticleTag;

internal sealed class AddArticleTagCommandHandler
    (IArticleRepository articleRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddArticleTagCommand, AddArticleTagResponse>
{

    public async Task<Result<AddArticleTagResponse>> Handle(AddArticleTagCommand request, CancellationToken cancellationToken)
    {
        
        Article? blog = await articleRepository.GetByIdAsync(request.ArticleId);
        if (blog is null)
        {
            return Result.Failure<AddArticleTagResponse>(ArticleErrors.NotFound(request.ArticleId));
        }
        
        // TODO: Find Tags With TagIds
        
        blog.AddTag(new(request.TagId, request.ArticleId));

        articleRepository.Update(blog);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new AddArticleTagResponse(blog.Id);
    }
}
