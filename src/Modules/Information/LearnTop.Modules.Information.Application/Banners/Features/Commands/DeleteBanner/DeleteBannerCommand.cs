using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Information.Application.Banners.Features.Commands.DeleteBanner;

public record DeleteBannerCommand(Guid BannerId) : ICommand<DeleteBannerResponse>;
