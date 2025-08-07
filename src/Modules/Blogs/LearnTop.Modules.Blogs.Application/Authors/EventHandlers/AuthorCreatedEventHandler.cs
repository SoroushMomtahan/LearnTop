using LearnTop.Modules.Blogs.Application.Authors.Services;
using LearnTop.Modules.Blogs.Application.Authors.Views;
using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Events;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Blogs.Application.Authors.EventHandlers;

internal sealed class AuthorCreatedEventHandler(IAuthorQueryService authorQueryService)
    : IDomainEventHandler<AuthorCreatedEvent>
{

    public async Task Handle(
        AuthorCreatedEvent notification, 
        CancellationToken cancellationToken)
    {
        AuthorView authorView = new()
        {
            Id = notification.Author.Id,
            Username = notification.Author.Username,
            DisplayName = notification.Author.DisplayName,
        };
        await authorQueryService.CreateAsync(authorView, cancellationToken);
        await authorQueryService.SaveChangesAsync(cancellationToken);
    }
}
