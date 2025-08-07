using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.CreatePrivateArticle;

internal sealed class CreatePrivateArticleCommandHandler(
    IArticleRepository articleRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreatePrivateArticleCommand, CreatePrivateArticleCommand.Response>
{

    public async Task<Result<CreatePrivateArticleCommand.Response>> Handle(
        CreatePrivateArticleCommand request, 
        CancellationToken cancellationToken)
    {
        var article = Article.CreatePrivate(request.AuthorId);
        await articleRepository.CreateAsync(article);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreatePrivateArticleCommand.Response(article.Id);
    }
}
