using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Application.Messaging;
using Microsoft.EntityFrameworkCore;
using Tagging.Data.ReadDb;
using Tagging.Tags.Views;

namespace Tagging.Tags.Features.UpdateTag;

internal sealed class TagUpdatedEventHandler(TaggingViewDbContext taggingViewDbContext) : IDomainEventHandler<Events.TagUpdatedEvent>
{

    public async Task Handle(Events.TagUpdatedEvent notification, CancellationToken cancellationToken)
    {
        TagView? tagView = await taggingViewDbContext.TagViews.FirstOrDefaultAsync(x => x.Id == notification.Tag.Id, cancellationToken);
        if (tagView is null)
        {
            throw new LearnTopException(nameof(TagUpdatedEventHandler));
        }
        tagView.Title = notification.Tag.Title;
        tagView.Description = notification.Tag.Description;
        tagView.IsDeleted = notification.Tag.IsDeleted;
        await taggingViewDbContext.SaveChangesAsync(cancellationToken);
    }
}
