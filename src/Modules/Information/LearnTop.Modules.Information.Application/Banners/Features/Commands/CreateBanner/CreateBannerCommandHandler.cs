using LearnTop.Modules.Information.Application.Abstractions.Data;
using LearnTop.Modules.Information.Domain.Banners.Models;
using LearnTop.Modules.Information.Domain.Banners.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Application.Banners.Features.Commands.CreateBanner;

public class CreateBannerCommandHandler(
    IBannerRepository bannerRepository,
    IUnitOfWork unitOfWork
    )
    : ICommandHandler<CreateBannerCommand, CreateBannerResponse>
{

    public async Task<Result<CreateBannerResponse>> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
    {
        Result<Banner> bannerResult = Banner.Create(request.Title, request.Description, request.StartAt, request.EndAt);
        if (bannerResult.IsFailure)
        {
            return Result.Failure<CreateBannerResponse>(bannerResult.Error);
        }
        await bannerRepository.CreateAsync(bannerResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new CreateBannerResponse(bannerResult.Value.Id);
    }
}
