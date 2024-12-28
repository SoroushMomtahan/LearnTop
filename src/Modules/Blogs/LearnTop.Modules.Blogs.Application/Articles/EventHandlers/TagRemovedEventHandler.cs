using LearnTop.Modules.Blogs.Domain.Articles.Events;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Blogs.Application.Articles.EventHandlers;

internal sealed class TagRemovedEventHandler
    (IArticleTagViewRepository articleTagViewRepository)
    : IDomainEventHandler<TagRemovedEvent>
{

    public async Task Handle(TagRemovedEvent notification, CancellationToken cancellationToken)
    {
        ArticleTagView? articleTagView = await articleTagViewRepository
            .GetArticleTagViewAsync(
                notification.ArticleTag.ArticleId,
                notification.ArticleTag.TagId
                );
        if (articleTagView is null)
        {
            throw new LearnTopException(nameof(ArticleTagView));
        }
        articleTagViewRepository.Delete(articleTagView);
        await articleTagViewRepository.SaveChangesAsync(cancellationToken);
    }
}
