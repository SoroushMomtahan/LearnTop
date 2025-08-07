using LearnTop.Modules.Files.Application.Features.Command.AddFile;
using LearnTop.Modules.Files.Application.Features.Queries.GetImageFileSettings;
using LearnTop.Modules.Files.Domain.Files.Models;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Files.Presentation.Files.AddImageFile;

internal sealed class AddImageFileEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/ImageFile/{ownerId:guid}", async (IFormFile file, Guid ownerId, ISender sender) =>
            {
                Result<GetImageFileSettingsQuery.Response> imageSettingResult = await sender.Send(
                    new GetImageFileSettingsQuery());
                if (imageSettingResult.IsFailure)
                {
                    return ApiResults.Problem(imageSettingResult);
                }
                ImageFileSetting imageFileSetting = imageSettingResult.Value.ImageFileSetting;

                AddFileCommand addFileCommand = new(
                    ownerId,
                    file,
                    imageFileSetting.ValidFormat,
                    imageFileSetting.MaxSizeByMb);

                Result<AddFileCommand.Response> addFileResult = await sender.Send(addFileCommand);
                if (addFileResult.IsFailure)
                {
                    return ApiResults.Problem(addFileResult);
                }
                return Results.Ok(addFileResult.Value);
            })
            .WithTags(Tags.Files)
            .DisableAntiforgery();
    }
}
