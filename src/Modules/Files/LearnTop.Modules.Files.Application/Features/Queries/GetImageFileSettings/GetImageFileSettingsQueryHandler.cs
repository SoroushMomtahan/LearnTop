using LearnTop.Modules.Files.Domain.Files.Models;
using LearnTop.Modules.Files.Domain.Files.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Files.Application.Features.Queries.GetImageFileSettings;

internal sealed class GetImageFileSettingsQueryHandler(
    IImageFileRepository imageFileRepository)
    : IQueryHandler<GetImageFileSettingsQuery, GetImageFileSettingsQuery.Response>
{

    public async Task<Result<GetImageFileSettingsQuery.Response>> Handle(
        GetImageFileSettingsQuery request, 
        CancellationToken cancellationToken)
    {
        ImageFileSetting imageFileSetting = await imageFileRepository.GetFirstAsync();
        return new GetImageFileSettingsQuery.Response(imageFileSetting);
    }
}
