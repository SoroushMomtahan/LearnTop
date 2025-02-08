using LearnTop.Modules.Identity.Application.Users.Features.Queries.VerifyEmail;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Identity.Presentation.Users.VerifyEmail;

internal sealed class VerifyEmailEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/VerifyEmail", async ([AsParameters] VerifyEmailQuery query, ISender sender) =>
        {
            Result<VerifyEmailResponse> result = await sender.Send(query);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Identity);
    }
}
