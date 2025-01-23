using LearnTop.Shared.Application.Messaging;
using Tagging.Data.ReadDb;
using Tagging.Tags.Views;

namespace Tagging.Tags.Features.CreateTag;

internal sealed class TagCreatedEventHandler(
    TaggingViewDbContext taggingViewDbContext) : IDomainEventHandler<Events.TagCreatedEvent>
{

    public async Task Handle(Events.TagCreatedEvent notification, CancellationToken cancellationToken)
    {
        TagView tagView = new()
        {
            Id = notification.Tag.Id,
            Title = notification.Tag.Title,
            Description = notification.Tag.Description,
            IsDeleted = notification.Tag.IsDeleted,
            CreatedAt = notification.Tag.CreatedAt,
            UpdatedAt = notification.Tag.UpdatedAt,
            DeletedAt = notification.Tag.DeletedAt,
        };
        await taggingViewDbContext.AddAsync(tagView, cancellationToken);
        await taggingViewDbContext.SaveChangesAsync(cancellationToken);
    }
}
