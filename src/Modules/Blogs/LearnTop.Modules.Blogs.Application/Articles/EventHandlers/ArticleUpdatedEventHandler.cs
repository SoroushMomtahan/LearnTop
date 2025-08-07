using LearnTop.Modules.Blogs.Application.Articles.Services;
using LearnTop.Modules.Blogs.Application.Articles.Views;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Events;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Blogs.Application.Articles.EventHandlers;

internal sealed class ArticleUpdatedEventHandler(
    IArticleQueryService articleQueryService)
    : IDomainEventHandler<ArticleUpdatedEvent>
{

    public async Task Handle(ArticleUpdatedEvent notification, CancellationToken cancellationToken)
    {
        
        ArticleView? articleView = await articleQueryService.GetByIdAsync(notification.Article.Id);
        if (articleView is null)
        {
            throw new LearnTopException(nameof(ArticleUpdatedEventHandler), ArticleErrors.NotFound(notification.Article.Id));
        }
        
        //Todo: Check CategorySnapshot
        //Todo: Check TagSnapshot
        
        
        articleView.Id = notification.Article.Id;
        articleView.Title = notification.Article.Title.Value;
        articleView.Content = notification.Article.Content;
        articleView.Status = notification.Article.Status.ToString();
        articleView.IsDeleted = notification.Article.IsDeleted;
        articleView.CreatedAt = notification.Article.CreatedAt;
        articleView.UpdatedAt = notification.Article.UpdatedAt;
        articleView.DeletedAt = notification.Article.DeletedAt;
        
        await articleQueryService.SaveChangesAsync(cancellationToken);
    }
}
