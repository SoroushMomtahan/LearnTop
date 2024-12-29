using LearnTop.Modules.Blogs.Domain.Articles.Events;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Blogs.Application.Articles.EventHandlers;

internal sealed class ArticleDeletedEventHandler(IArticleViewRepository articleViewRepository) : IDomainEventHandler<ArticleDeletedEvent>
{

    public async Task Handle(ArticleDeletedEvent notification, CancellationToken cancellationToken)
    {
        ArticleView? articleView = await articleViewRepository.GetByIdAsync(notification.Article.Id);
        if (articleView is null)
        {
            throw new LearnTopException(nameof(ArticleDeletedEvent));
        }
        articleViewRepository.Delete(articleView);
        await articleViewRepository.SaveChangesAsync(cancellationToken);
    }
}
