using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots;
using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Features.GetUserSnapshotById;
using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Services;
using LearnTop.Modules.Blogs.Application.Views.ArticleViews;
using LearnTop.Modules.Blogs.Application.Views.ArticleViews.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Events;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Application.Messaging;
using LearnTop.Shared.Domain;
using MediatR;

namespace LearnTop.Modules.Blogs.Application.Articles.EventHandlers;

internal sealed class ArticleCreatedEventHandler(
    IArticleViewRepository articleViewRepository,
    ISender sender)
    : IDomainEventHandler<ArticleCreatedEvent>
{

    public async Task Handle(ArticleCreatedEvent notification, CancellationToken cancellationToken)
    {
        Result<GetUserSnapshotByIdQuery.Response> result = await sender.Send(
            new GetUserSnapshotByIdQuery(notification.Article.AuthorId), 
            cancellationToken);
        if (result.IsFailure)
        {
            throw new LearnTopException(nameof(GetUserSnapshotByIdQuery), result.Error);
        }
        AuthorView authorView = new()
        {
            Id = result.Value.UserSnapshot.UserId,
            Name = result.Value.UserSnapshot.Username
        };
        ArticleView articleView = new()
        {
            Id = notification.Article.Id,
            CategoryId = notification.Article.CategoryId,
            TagIds = [.. notification.Article.TagIds],
            AuthorView = authorView,
            CoverName = notification.Article.CoverName,
            Title = notification.Article.Title,
            Content = notification.Article.Content,
            ShortContent = notification.Article.ShortContent.ToString(),
            Status = notification.Article.Status.ToString(),
            IsDeleted = notification.Article.IsDeleted,
            CreatedAt = notification.Article.CreatedAt,
            DeletedAt = notification.Article.DeletedAt,
            UpdatedAt = notification.Article.UpdatedAt,
        };
        await articleViewRepository.AddAsync(articleView);
        await articleViewRepository.SaveChangesAsync(cancellationToken);
    }
}
