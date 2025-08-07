using LearnTop.Modules.Blogs.Application.Articles.Features.Commands.UpdateArticle;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.UpdateArticle;

internal sealed class UpdateArticleEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/Articles", async (UpdateArticleCommand command, ISender sender) =>
        {
            Result<UpdateArticleResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles)
        .RequireAuthorization();
    }
}
