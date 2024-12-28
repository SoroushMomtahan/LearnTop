using LearnTop.Modules.Blogs.Domain.Articles.Events;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Blogs.Application.Articles.EventHandlers;

internal sealed class TagAddedEventHandler
    (IArticleTagViewRepository articleTagViewRepository)
    : IDomainEventHandler<TagAddedEvent>
{

    public async Task Handle(TagAddedEvent notification, CancellationToken cancellationToken)
    {
        ArticleTagView articleTagView = new()
        {
            TagId = notification.ArticleTag.TagId,
            ArticleId = notification.ArticleTag.ArticleId,
            CreatedAt = notification.ArticleTag.CreatedAt,
            UpdatedAt = notification.ArticleTag.UpdatedAt,
            DeletedAt = notification.ArticleTag.DeletedAt,
        };
        await articleTagViewRepository.AddAsync(articleTagView);
        await articleTagViewRepository.SaveChangesAsync(cancellationToken);
    }
}
