using LearnTop.Modules.Identity.Application.Users.Features.Commands.SignUpWithEmail;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Identity.Presentation.Users.SignUpWithEmail;

internal sealed class SignUpWithEmailEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Identity/SignUp", async (SignUpWithEmailCommand command, ISender sender) =>
        {
            Result<SignUpWithEmailResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Identity);
    }
}
