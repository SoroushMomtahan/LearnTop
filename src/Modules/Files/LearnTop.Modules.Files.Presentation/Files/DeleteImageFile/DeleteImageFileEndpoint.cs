using LearnTop.Modules.Files.Application.Features.Command.DeleteFile;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Files.Presentation.Files.DeleteImageFile;

internal sealed class DeleteImageFileEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/ImageFile/{fileName}", async (string fileName, ISender sender) =>
        {
            Result result = await sender.Send(new DeleteFileCommand(fileName));
            return result.Match(() => Results.Ok(), ApiResults.Problem);
        })
        .WithTags(Tags.Files);
    }
}
