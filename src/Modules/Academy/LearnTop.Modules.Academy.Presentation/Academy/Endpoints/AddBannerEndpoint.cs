using LearnTop.Modules.Academy.Application.Academy.Commands.AddBanner;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Academy.Presentation.Academy.Endpoints;

public class AddBannerEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Banners", static async (AddBannerCommand command, ISender sender) =>
        {
            Result<AddBannerResponse> result = await sender.Send(command);
            return result.Match(Results.Created, ApiResults.Problem);
        })
        .WithTags(Tags.Banners);
    }
}
