using System.Security.Claims;
using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.DeleteArticle;
using Serilog;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.DeleteArticle;

internal sealed class DeleteArticleEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Articles/{id:guid}", async (Guid id,  ISender sender, ClaimsPrincipal user) =>
            {
                if (user.Identity is { Name: not null })
                {
                    Log.Information(user.Identity.Name);
                }
                Result<DeleteArticleResponse> result = await sender.Send(new DeleteArticleCommand(id, false));
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Articles);
    }
}
