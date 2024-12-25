using LearnTop.Modules.Academy.Application.Abstractions.Data;
using LearnTop.Modules.Academy.Domain.Academy.Models;
using LearnTop.Modules.Academy.Domain.Academy.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Application.Academy.Commands.AddBanner;

public class AddBannerCommandHandler(
    IBannerRepository bannerRepository,
    IUnitOfWork unitOfWork
    )
    : ICommandHandler<AddBannerCommand, AddBannerResponse>
{

    public async Task<Result<AddBannerResponse>> Handle(AddBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = Banner.Create(
            request.Image,
            request.Title,
            request.StartAt,
            request.EndAt
            );
        await bannerRepository.AddAsync(banner);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new AddBannerResponse(banner.Id);
    }
}
