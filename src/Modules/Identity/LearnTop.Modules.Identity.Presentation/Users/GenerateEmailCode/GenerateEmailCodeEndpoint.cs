using LearnTop.Modules.Identity.Application.Users.Features.Commands.GenerateEmailCode;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Identity.Presentation.Users.GenerateEmailCode;

internal sealed class GenerateEmailCodeEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Identity/GenerateEmailCode", async (GenerateEmailCodeCommand command, ISender sender) =>
        {
            Result<GenerateEmailCodeResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Identity);
    }
}
