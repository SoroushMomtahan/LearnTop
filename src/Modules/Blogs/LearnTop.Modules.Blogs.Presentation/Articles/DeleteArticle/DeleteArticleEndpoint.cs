using System.Security.Claims;
using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.DeleteArticle;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LearnTop.Modules.Blogs.Presentation.Articles.DeleteArticle;

internal sealed class DeleteArticleEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Articles", async ([AsParameters] DeleteArticleCommand command, ISender sender, ClaimsPrincipal user) =>
            {
                if (user.Identity is { Name: not null })
                {
                    Log.Information(user.Identity.Name);
                }
                Result<DeleteArticleResponse> result = await sender.Send(command);
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Articles)
            .RequireAuthorization();
    }
}
