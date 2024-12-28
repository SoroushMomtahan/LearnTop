using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.DeleteArticle;

namespace LearnTop.Modules.Blogs.Presentation.Articles.DeleteArticle;

internal sealed class DeleteArticleEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Articles", async ([AsParameters]DeleteArticleCommand command, ISender sender) =>
        {
            Result<DeleteArticleResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles);
    }
}
