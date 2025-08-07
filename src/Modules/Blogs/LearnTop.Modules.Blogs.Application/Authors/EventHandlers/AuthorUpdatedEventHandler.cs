using LearnTop.Modules.Blogs.Application.Articles.Services;
using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Events;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Blogs.Application.Authors.EventHandlers;

internal sealed class AuthorUpdatedEventHandler(IArticleQueryService articleQueryService)
    : IDomainEventHandler<AuthorUpdatedEvent>
{

    public Task Handle(
        AuthorUpdatedEvent notification, 
        CancellationToken cancellationToken)
    {
        articleQueryService.BulkUpdateByAuthorIdAsync(
            notification.Author.Id, 
            notification.Author.Username, 
            notification.Author.DisplayName, 
            cancellationToken);
        
        return Task.CompletedTask;
    }
}
