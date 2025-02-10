using LearnTop.Modules.Information.Application.Banners.Features.Commands.DeleteBanner;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Academy.Presentation.Banners.Endpoints.DeleteBanner;

internal sealed class DeleteBannerEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Banner", async ([AsParameters] DeleteBannerCommand command, ISender sender) =>
        {
            Result<DeleteBannerResponse> result = await sender.Send(new DeleteBannerCommand(command.BannerId));
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Banners);
    }
}
