using LearnTop.Modules.Identity.Application.Users.Features.Commands.SignInWithEmail;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Identity.Presentation.Users.SignInWithEmail;

internal sealed class SignInWithEmailEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Identity/SignIn", async ([AsParameters] SignInWithEmailCommand command, ISender sender) =>
        {
            Result<SignInWithEmailResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Identity);
    }
}
