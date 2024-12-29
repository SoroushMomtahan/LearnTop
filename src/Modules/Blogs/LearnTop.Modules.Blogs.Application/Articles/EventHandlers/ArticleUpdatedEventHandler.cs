using LearnTop.Modules.Blogs.Domain.Articles.Events;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Blogs.Application.Articles.EventHandlers;

internal sealed class ArticleUpdatedEventHandler
    (IArticleViewRepository articleViewRepository) 
    : IDomainEventHandler<ArticleUpdatedEvent>
{

    public async Task Handle(ArticleUpdatedEvent notification, CancellationToken cancellationToken)
    {
        ArticleView articleView = new()
        {
            Id = notification.Article.Id,
            CreatedAt = notification.Article.CreatedAt,
            AuthorId = notification.Article.AuthorId,
            CategoryId = notification.Article.CategoryId,
            Content = notification.Article.Content,
            DeletedAt = notification.Article.DeletedAt,
            IsDeleted = notification.Article.IsDeleted,
            Status = notification.Article.Status.ToString(),
            Title = notification.Article.Title
        };
        articleViewRepository.Update(articleView);
        await articleViewRepository.SaveChangesAsync(cancellationToken);
    }
}
