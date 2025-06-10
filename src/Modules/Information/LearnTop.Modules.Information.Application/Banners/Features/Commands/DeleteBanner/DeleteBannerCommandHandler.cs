using LearnTop.Modules.Information.Application.Abstractions.Data;
using LearnTop.Modules.Information.Domain.Banners.Errors;
using LearnTop.Modules.Information.Domain.Banners.Models;
using LearnTop.Modules.Information.Domain.Banners.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Application.Banners.Features.Commands.DeleteBanner;

internal sealed class DeleteBannerCommandHandler(
    IBannerRepository bannerRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteBannerCommand, DeleteBannerResponse>
{

    public async Task<Result<DeleteBannerResponse>> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
    {
        Banner? banner = await bannerRepository.GetAsync(request.BannerId, cancellationToken);
        if (banner is null)
        {
            return Result.Failure<DeleteBannerResponse>(BannerErrors.NotFound);
        }
        
        // Todo: Delete Banner Image File
        
        bannerRepository.Delete(banner);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new DeleteBannerResponse(true);
    }
}
