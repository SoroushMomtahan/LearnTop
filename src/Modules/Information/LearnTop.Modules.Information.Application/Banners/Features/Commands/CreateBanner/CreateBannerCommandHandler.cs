using LearnTop.Modules.Information.Application.Abstractions.Data;
using LearnTop.Modules.Information.Domain.Banners.Errors;
using LearnTop.Modules.Information.Domain.Banners.Models;
using LearnTop.Modules.Information.Domain.Banners.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Services;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Application.Banners.Features.Commands.CreateBanner;

public class CreateBannerCommandHandler(
    IFileService fileService,
    IBannerRepository bannerRepository,
    IUnitOfWork unitOfWork
    )
    : ICommandHandler<CreateBannerCommand, CreateBannerResponse>
{

    public async Task<Result<CreateBannerResponse>> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
    {
        BannerSetting? setting = await bannerRepository.GetSettingsAsync(cancellationToken);

        if (setting == null)
        {
            return Result.Failure<CreateBannerResponse>(BannerErrors.SettingsNotFound);
        }
        
        string extension = Path.GetExtension(request.Image.FileName).Replace(".", "");
        List<string> validExtensions = setting.ValidExtensions;
        int maxSize = setting.MaxSize;
        
        var banner = new Banner(
            extension,
            [.. validExtensions],
            maxSize,
            nameof(Banner)
            );
        
        banner.AddTitle(request.Title);
        banner.AddDescription(request.Description);
        banner.SetBannerLifetime(request.StartAt, request.EndAt);

        await fileService.SaveAsync(request.Image, banner.Name);
        
        await bannerRepository.CreateAsync(banner, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new CreateBannerResponse(banner.Id);
    }
}
