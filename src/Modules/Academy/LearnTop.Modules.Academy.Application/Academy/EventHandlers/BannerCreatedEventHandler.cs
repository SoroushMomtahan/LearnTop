using LearnTop.Modules.Academy.Domain.Academy.Events;
using LearnTop.Modules.Academy.Domain.Academy.Repositories.Views;
using LearnTop.Modules.Academy.Domain.Academy.ViewModels;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Academy.Application.Academy.EventHandlers;

public class BannerCreatedEventHandler(
    IBannerViewRepository bannerViewRepository)
    : IDomainEventHandler<BannerCreatedEvent>
{

    public async Task Handle(BannerCreatedEvent notification, CancellationToken cancellationToken)
    {
        BannerView bannerView = new()
        {
            Id = notification.Banner.Id,
            CreatedAt = notification.Banner.CreatedAt,
            DeletedAt = notification.Banner.DeletedAt,
            EndAt = notification.Banner.EndAt,
            Title = notification.Banner.Title,
            ImageUrl = notification.Banner.ImageUrl,
            StartAt = notification.Banner.StartAt,
            UpdatedAt = notification.Banner.UpdatedAt,
        };
        await bannerViewRepository.AddAsync(bannerView);
        await bannerViewRepository.SaveChangesAsync(cancellationToken);
    }
}
