using LearnTop.Modules.Blogs.Application.Articles.Services;
using LearnTop.Modules.Blogs.Application.Articles.Views;
using LearnTop.Modules.Blogs.Application.Authors.Features.Queries.GetAuthorById;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Events;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Application.Messaging;
using LearnTop.Shared.Domain;
using MediatR;

namespace LearnTop.Modules.Blogs.Application.Articles.EventHandlers;

internal sealed class ArticleCreatedEventHandler(
    IArticleQueryService articleQueryService,
    ISender sender)
    : IDomainEventHandler<ArticleCreatedEvent>
{

    public async Task Handle(
        ArticleCreatedEvent notification, 
        CancellationToken cancellationToken)
    {
        Guid authorId = notification.Article.AuthorId;
        Result<GetAuthorByIdQuery.Result> result = await sender.Send(new GetAuthorByIdQuery(authorId), cancellationToken);
        if (result.IsFailure)
        {
            throw new LearnTopException(nameof(GetAuthorByIdQuery), Error.NullValue);
        }
        
        ArticleView articleView = new()
        {
            Id = notification.Article.Id,
            AuthorId = authorId,
            AuthorUsername = result.Value.AuthorView.Username,
            AuthorDisplayName = result.Value.AuthorView.DisplayName,
            CategoryId = notification.Article.CategoryId,
            TagIds = [.. notification.Article.TagIds],
            CoverName = notification.Article.CoverName,
            Title = notification.Article.Title.Value,
            Content = notification.Article.Content,
            ShortContent = notification.Article.ShortContent.ToString(),
            Status = notification.Article.Status.ToString(),
            IsDeleted = notification.Article.IsDeleted,
            CreatedAt = notification.Article.CreatedAt,
            DeletedAt = notification.Article.DeletedAt,
            UpdatedAt = notification.Article.UpdatedAt,
        };
        await articleQueryService.AddAsync(articleView);
        await articleQueryService.SaveChangesAsync(cancellationToken);
    }
}
