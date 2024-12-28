using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.AddArticleTag;


namespace LearnTop.Modules.Blogs.Presentation.Articles.AddArticleTag;

internal sealed class AddArticleTagEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Articles/Tag", async (AddArticleTagCommand command, ISender sender) =>
        {
            Result<AddArticleTagResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles);
    }
}
