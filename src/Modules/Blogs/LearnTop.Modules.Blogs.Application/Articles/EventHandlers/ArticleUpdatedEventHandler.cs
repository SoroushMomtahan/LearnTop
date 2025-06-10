using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots;
using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Services;
using LearnTop.Modules.Blogs.Application.Views.ArticleViews;
using LearnTop.Modules.Blogs.Application.Views.ArticleViews.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Events;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Blogs.Application.Articles.EventHandlers;

internal sealed class ArticleUpdatedEventHandler(
    IArticleViewRepository articleViewRepository,
    IUserSnapshotRepository userSnapshotRepository)
    : IDomainEventHandler<ArticleUpdatedEvent>
{

    public async Task Handle(ArticleUpdatedEvent notification, CancellationToken cancellationToken)
    {
        
        ArticleView? articleView = await articleViewRepository.GetByIdAsync(notification.Article.Id);
        if (articleView is null)
        {
            throw new LearnTopException(nameof(ArticleUpdatedEventHandler), ArticleErrors.NotFound(notification.Article.Id));
        }
        
        UserSnapshot? userSnapshot = await userSnapshotRepository.GetAsync(
            notification.Article.AuthorId, 
            cancellationToken);
        if (userSnapshot is null)
        {
            throw new ApplicationException("User snapshot is null");
        }
        AuthorView authorView = new()
        {
            Id = userSnapshot.UserId,
            Name = userSnapshot.Username
        };
        //Todo: Check CategorySnapshot
        //Todo: Check TagSnapshot
        
        
        articleView.Id = notification.Article.Id;
        articleView.AuthorView = authorView;
        articleView.Title = notification.Article.Title;
        articleView.Content = notification.Article.Content;
        articleView.Status = notification.Article.Status.ToString();
        articleView.IsDeleted = notification.Article.IsDeleted;
        articleView.CreatedAt = notification.Article.CreatedAt;
        articleView.UpdatedAt = notification.Article.UpdatedAt;
        articleView.DeletedAt = notification.Article.DeletedAt;
        
        await articleViewRepository.SaveChangesAsync(cancellationToken);
    }
}
