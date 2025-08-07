using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.AddArticleTag;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.AddArticleTag;

internal sealed class AddArticleTagEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Articles/Tag", async (AddArticleTagCommand articleTagCommand, ISender sender) =>
            {
                Result<AddArticleTagResponse> result = await sender.Send(articleTagCommand);
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Articles)
            .RequireAuthorization();
    }
}
