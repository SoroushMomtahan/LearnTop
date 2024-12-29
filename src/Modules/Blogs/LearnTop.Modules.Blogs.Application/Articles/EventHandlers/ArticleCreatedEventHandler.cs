using LearnTop.Modules.Blogs.Domain.Articles.Events;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Blogs.Application.Articles.EventHandlers;

internal sealed class ArticleCreatedEventHandler(IArticleViewRepository articleViewRepository) : IDomainEventHandler<ArticleCreatedEvent> 
{

    public async Task Handle(ArticleCreatedEvent notification, CancellationToken cancellationToken)
    {
        ArticleView articleView = new()
        {
            Id = notification.Article.Id,
            AuthorId = notification.Article.AuthorId,
            CategoryId = notification.Article.CategoryId,
            Title = notification.Article.Title,
            Content = notification.Article.Content,
            Status = notification.Article.Status.ToString(),
            IsDeleted = notification.Article.IsDeleted,
            CreatedAt = notification.Article.CreatedAt,
            DeletedAt = notification.Article.DeletedAt,
        };
        await articleViewRepository.AddAsync(articleView);
        await articleViewRepository.SaveChangesAsync(cancellationToken);
    }
}
