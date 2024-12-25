using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Academy.Application.Academy.Commands.AddBanner;

public record AddBannerCommand(
    string Image,
    string Title,
    DateTime StartAt,
    DateTime EndAt
    ) : ICommand<AddBannerResponse>;
