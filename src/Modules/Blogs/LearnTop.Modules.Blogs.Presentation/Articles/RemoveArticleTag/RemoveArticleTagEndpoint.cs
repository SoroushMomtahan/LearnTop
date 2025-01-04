using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.RemoveArticleTag;

namespace LearnTop.Modules.Blogs.Presentation.Articles.RemoveArticleTag;

internal sealed class RemoveArticleTagEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Articles/Tag", async ([AsParameters] RemoveArticleTagCommand command, ISender sender) =>
        {
            Result<RemoveArticleTagResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles)
        .RequireAuthorization();
    }
}
