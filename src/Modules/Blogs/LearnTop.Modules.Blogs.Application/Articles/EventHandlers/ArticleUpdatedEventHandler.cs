using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Events;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Blogs.Application.Articles.EventHandlers;

internal sealed class ArticleUpdatedEventHandler
    (IArticleViewRepository articleViewRepository) 
    : IDomainEventHandler<ArticleUpdatedEvent>
{

    public async Task Handle(ArticleUpdatedEvent notification, CancellationToken cancellationToken)
    {
        
        ArticleView? articleView = await articleViewRepository.GetByIdAsync(notification.Article.Id);
        if (articleView is null)
        {
            throw new LearnTopException(nameof(ArticleUpdatedEventHandler), ArticleErrors.NotFound(notification.Article.Id));
        }
        var articleTagViews = notification.Article.Tags
            .Select(x => 
                new ArticleTagView
                {
                    ArticleId = x.ArticleId, 
                    TagId = x.TagId,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    DeletedAt = x.DeletedAt
                })
            .ToList();
        articleView.TagViews = articleTagViews;
        articleView.Id = notification.Article.Id;
        articleView.AuthorId = notification.Article.AuthorId;
        articleView.CategoryId = notification.Article.CategoryId;
        articleView.Title = notification.Article.Title;
        articleView.Content = notification.Article.Content;
        articleView.Status = notification.Article.Status.ToString();
        articleView.IsDeleted = notification.Article.IsDeleted;
        articleView.CreatedAt = notification.Article.CreatedAt;
        articleView.UpdatedAt = notification.Article.UpdatedAt;
        articleView.DeletedAt = notification.Article.DeletedAt;
        articleView.TagViews = articleTagViews;
        
        await articleViewRepository.SaveChangesAsync(cancellationToken);
    }
}
