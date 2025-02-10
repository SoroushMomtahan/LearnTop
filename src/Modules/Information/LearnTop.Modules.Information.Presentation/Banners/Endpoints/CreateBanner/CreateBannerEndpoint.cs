using LearnTop.Modules.Information.Application.Banners.Features.Commands.CreateBanner;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Academy.Presentation.Banners.Endpoints;

public class CreateBannerEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Banners", static async ([FromForm]CreateBannerCommand command, ISender sender) =>
        {
            Result<CreateBannerResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Banners)
        .DisableAntiforgery();
    }
}
