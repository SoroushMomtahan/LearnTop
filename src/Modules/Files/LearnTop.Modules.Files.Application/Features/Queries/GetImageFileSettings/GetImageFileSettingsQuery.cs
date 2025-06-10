using LearnTop.Modules.Files.Domain.Files.Models;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Files.Application.Features.Queries.GetImageFileSettings;

public record GetImageFileSettingsQuery() : IQuery<GetImageFileSettingsQuery.Response>
{
    public record Response(ImageFileSetting ImageFileSetting);
}
